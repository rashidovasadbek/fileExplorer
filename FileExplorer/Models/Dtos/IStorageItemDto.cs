using FileExplorer.Applicatoin.FIleStorege.Models.Storage;

namespace FileExplorer.Models.Dtos;

public interface IStorageItemDto
{
    string Path { get; set; }
    
    StorageEntryType EntryType { get; set; }
}