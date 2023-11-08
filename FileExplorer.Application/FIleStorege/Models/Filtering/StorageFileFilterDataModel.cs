using FileExplorer.Applicatoin.Common.Filtering;

namespace FileExplorer.Applicatoin.FIleStorege.Models.Filtering;

public class StorageFileFilterDataModel
{
    public List<StorageFilesSummary> FilterData { get; set; } = new();
}