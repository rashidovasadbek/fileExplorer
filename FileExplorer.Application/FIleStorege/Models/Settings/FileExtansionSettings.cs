using FileExplorer.Applicatoin.FIleStorege.Models.Filtering;

namespace FileExplorer.Applicatoin.FIleStorege.Models.Settings;

public class FileExtansionSettings
{
    public StorageFileType FileType { get; set; }

    public string DisplayName { get; set; } = string.Empty;

    public string ImageUrl { get; set; } = string.Empty;

    public ICollection<string> Extensions { get; set; } = default!;
}