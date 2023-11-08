using FileExplorer.Applicatoin.FIleStorege.Models.Filtering;
using FileExplorer.Applicatoin.FIleStorege.Models.Storage;

namespace FileExplorer.Applicatoin.Common.Filtering;

public class StorageFilesSummary
{
    public  StorageFileType FileType { get; set; }
    
    public string DisplayName { get; set; }
    
    public long Count { get; set; }
    
    public long Size { get; set; }
    
    public string ImageUrl { get; set; } = string.Empty;
}