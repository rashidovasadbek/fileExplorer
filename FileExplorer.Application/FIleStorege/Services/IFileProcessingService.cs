using FileExplorer.Applicatoin.FIleStorege.Models.Filtering;
using FileExplorer.Applicatoin.FIleStorege.Models.Storage;

namespace FileExplorer.Applicatoin.FIleStorege.Services;

public interface IFileProcessingService
{
    ValueTask<StorageFileFilterDataModel> GetFilterDataModelAsync(string directoryPath);

    ValueTask<IList<StorageFile>> GetByFilterAsync(StorageFileFilterModel filterModel);
}