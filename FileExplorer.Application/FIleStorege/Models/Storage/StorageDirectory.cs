namespace FileExplorer.Applicatoin.FIleStorege.Models.Storage;

public class StorageDirectory : IStorageEntry
{
    public string Name { get; set; } = string.Empty;

    public string Path { get; set; } = string.Empty;
    
    public long ItemsCount { get; set; }
    
    public StorageEntryType storageEntryType { get; set; } = StorageEntryType.Directory;
}