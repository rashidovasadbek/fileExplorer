namespace FileExplorer.Applicatoin.FIleStorege.Models.Storage;

public interface IStorageEntry
{
    public string Name { get; set; }
    public string Path { get; set; }
    public StorageEntryType storageEntryType { get; set; }
}