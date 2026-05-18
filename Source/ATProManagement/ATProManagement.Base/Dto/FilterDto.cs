
namespace ATPromanagement.Base
{
    public class FilterDto
    {
        public List<FilterItem> Filters { get; set; } = new();
    }

    public class FilterItem
    {
        public string Field { get; set; }
        public string Operator { get; set; }
        public string Value { get; set; }
    }
}
