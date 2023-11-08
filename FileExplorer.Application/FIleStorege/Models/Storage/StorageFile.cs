namespace FileExplorer.Applicatoin.FIleStorege.Models.Storage;

public class StorageFile : IStorageEntry
{
    public string Name { get; set; } = string.Empty;
    public string Path { get; set; } = string.Empty;
    public string DirectoryPath { get; set; } = string.Empty;
    public string FileExtension { get; set; } = string.Empty;
    public long Size {  get; set; } 
    public StorageEntryType storageEntryType { get ; set ; } = StorageEntryType.File;
}