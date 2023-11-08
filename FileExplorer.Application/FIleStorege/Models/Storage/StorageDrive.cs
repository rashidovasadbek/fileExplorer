namespace FileExplorer.Applicatoin.FIleStorege.Models.Storage;

public class StorageDrive : IStorageEntry
{
    public string Name { get ; set; } = string.Empty;
    public string Path { get; set ; } = string.Empty;
    public string Format {  get; set ; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public long TotaleSpace {  get; set; }
    public long FreeSpace { get; set; }
    public long UnavailableSpace { get; set; }
    public long UsedSpace { get; set; }
    public StorageEntryType storageEntryType { get; set ; }
}
