namespace FileExplorer.Applicatoin.FIleStorege.Models.Settings;

public class FileFilterSettings
{
    public ICollection<FileExtansionSettings> FileExtension { get; set; } = default!;
}