using FileExplorer.Applicatoin.FIleStorege.Models.Filtering;
using FileExplorer.Applicatoin.FIleStorege.Models.Storage;
using FileExplorer.Applicatoin.FIleStorege.Services;

namespace FileExplorer.Infrastructure.FileStorage.Services;

public class DirectoryProcessingService : IDirectoryProcessingService
{
    private readonly IDirectoryService _directoryService;

    public DirectoryProcessingService(IDirectoryService directoryService)
    {
        _directoryService = directoryService;
    }

    public async ValueTask<List<IStorageEntry>> GetEntriesAsync(string directoryPath, StorageDirectoryEntryFilterModel filterModel)
    {
        var storageItem = new List<IStorageEntry>();

        if (filterModel.IncludeDirectories)
            storageItem.AddRange(await _directoryService.GetDirectoriesAsync(directoryPath, filterModel));

        return storageItem;
    }
}