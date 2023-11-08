using FileExplorer.Applicatoin.Common.Filtering;

namespace FileExplorer.Applicatoin.FIleStorege.Models.Filtering;

public class StorageDirectoryEntryFilterModel : FilterPagination
{
    public bool IncludeDirectories { get; set; }
    
    public bool IncludeFiles { get; set; }
}