using ClosedXML.Excel;
using Microsoft.JSInterop;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System.Reflection;


namespace ATProManagement.Base
{
    public class DownloadHelper
    {
        public static async Task ExportToExcel<T>(
        List<T> data,
        IJSRuntime js,
        string sheetName = "Sheet1")
        {
            using var workbook = new XLWorkbook();

            var worksheet = workbook.Worksheets.Add(sheetName);

            var properties = typeof(T)
                .GetProperties(BindingFlags.Public | BindingFlags.Instance);

            // Header
            for (int col = 0; col < properties.Length; col++)
            {
                worksheet.Cell(1, col + 1)
                         .Value = properties[col].Name;

                worksheet.Cell(1, col + 1)
                         .Style.Font.Bold = true;
            }

            // Data
            for (int row = 0; row < data.Count; row++)
            {
                for (int col = 0; col < properties.Length; col++)
                {
                    var value = properties[col]
                        .GetValue(data[row]);

                    worksheet.Cell(row + 2, col + 1)
                             .Value = value?.ToString();
                }
            }

            worksheet.Columns().AdjustToContents();

            using var stream = new MemoryStream();

            workbook.SaveAs(stream);

            await js.InvokeVoidAsync(
                   "downloadFile",
                   sheetName,
                   "application/octet-stream",
                   stream.ToArray());
        }

        public static async Task ExportToPdf<T>(
        List<T> data,
        IJSRuntime js,
        string fileName = "Report")
        {
            QuestPDF.Settings.License = LicenseType.Community;

            var properties = typeof(T)
                .GetProperties(
                    BindingFlags.Public |
                    BindingFlags.Instance);

            var document = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Margin(20);

                    page.Header()
                        .Text(fileName)
                        .FontSize(20)
                        .Bold();

                    page.Content()
                        .Table(table =>
                        {
                            table.ColumnsDefinition(columns =>
                            {
                                foreach (var _ in properties)
                                {
                                    columns.RelativeColumn();
                                }
                            });

                            // Header
                            table.Header(header =>
                            {
                                foreach (var prop in properties)
                                {
                                    header.Cell()
                                        .Background(Colors.Grey.Lighten2)
                                        .Padding(5)
                                        .Text(prop.Name)
                                        .Bold();
                                }
                            });

                            // Rows
                            foreach (var item in data)
                            {
                                foreach (var prop in properties)
                                {
                                    var value = prop
                                        .GetValue(item)
                                        ?.ToString() ?? "";

                                    table.Cell()
                                        .Padding(5)
                                        .Text(value);
                                }
                            }
                        });

                    page.Footer()
                        .AlignCenter()
                        .Text(x =>
                        {
                            x.Span("Page ");
                            x.CurrentPageNumber();
                        });
                });
            });

            await js.InvokeVoidAsync(
                 "downloadFile",
                 fileName,
                 "application/pdf",
                 document.GeneratePdf());
        }
    }
}
