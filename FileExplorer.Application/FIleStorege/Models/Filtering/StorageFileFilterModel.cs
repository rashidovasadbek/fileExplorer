using FileExplorer.Applicatoin.Common.Filtering;

namespace FileExplorer.Applicatoin.FIleStorege.Models.Filtering;

public class StorageFileFilterModel : FilterPagination
{
    public string DirectoryPath { get; set; } = string.Empty;

    public ICollection<StorageFileType> FileTypes { get; set; } = default!;
}