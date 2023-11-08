using System.Text.Json.Serialization;

namespace FileExplorer.Applicatoin.Common.Filtering;

public class FilterPagination
{
    public virtual uint PageSize { get; set; } = 10;

    public virtual uint PageToken { get; set; } = 1;
    
    [JsonIgnore] private DynamicFilterPagination? DynamicPagination { get; set; }
    
    [JsonIgnore] public uint DynamicPageSize => DynamicPagination?.PageSize ?? PageSize;

    public void SetDynamicPagination(uint callsCount) =>
        DynamicPagination = new DynamicFilterPagination(this, callsCount);

    public void RestDynamicPagination() => DynamicPagination = null;
}
