using ATProManagement.Base;
using System.Threading.Tasks;
using CurrieTechnologies.Razor.SweetAlert2;

namespace ATProMangement.Blazor;

public class SweetAlertService : ISweetAlertService
{
    private readonly CurrieTechnologies.Razor.SweetAlert2.SweetAlertService _swal;
    public SweetAlertService(CurrieTechnologies.Razor.SweetAlert2.SweetAlertService swal)
    {
        _swal = swal;
    }

    public async Task Close()
    {
        await _swal.CloseAsync();
    }

    public async Task<bool> Confirm(string message, string title = "")
    {
        var result = await _swal.FireAsync(
           new SweetAlertOptions
           {
               Title = title,
               Text = message,
               Icon = SweetAlertIcon.Question,
               ShowCancelButton = true
           });

        return !string.IsNullOrEmpty(result.Value);
    }

    public async Task Error(string message, string title = "")
    {
        await _swal.FireAsync(
       "Error",
       message,
       SweetAlertIcon.Error);
    }

    public Task Loading(string message = "Loading...")
    {
        _ = _swal.FireAsync(new SweetAlertOptions
        {
            Html = $"""
                    <div style="display:flex;
                                align-items:center;
                                gap:12px;
                                padding:8px 12px;">

                        <div class="swal2-loader"
                             style="display:flex;"></div>

                        <span>{message}</span>

                    </div>
                    """,

            Text = message,

            Position = SweetAlertPosition.Center,

            ShowConfirmButton = false,

            AllowOutsideClick = false,
            AllowEscapeKey = false,

            Backdrop = false
        });
        return Task.CompletedTask;
    }

    public async Task Success(string message, string title = "")
    {
        await _swal.FireAsync(
             "Success",
             message,
             SweetAlertIcon.Success
        );
    }

    public Task Toast(string message)
    {
        throw new System.NotImplementedException();
    }

    public async Task Warning(string message, string title = "")
    {
        await _swal.FireAsync(
             "Warning",
             message,
             SweetAlertIcon.Warning
        );
    }
}

