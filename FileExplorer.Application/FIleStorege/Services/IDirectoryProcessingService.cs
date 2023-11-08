using FileExplorer.Applicatoin.FIleStorege.Models.Filtering;
using FileExplorer.Applicatoin.FIleStorege.Models.Storage;

namespace FileExplorer.Applicatoin.FIleStorege.Services;

public interface IDirectoryProcessingService
{
    ValueTask<List<IStorageEntry>> GetEntriesAsync(string directoryPath, StorageDirectoryEntryFilterModel filterModel);
}