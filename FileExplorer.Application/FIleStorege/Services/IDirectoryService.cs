using FileExplorer.Applicatoin.Common.Filtering;
using FileExplorer.Applicatoin.FIleStorege.Models.Storage;

namespace FileExplorer.Applicatoin.FIleStorege.Services;

public interface IDirectoryService
{
    IEnumerable<string> GetDirectoriesPath(string directoryPath, FilterPagination paginationOptions);

    IEnumerable<string> GetFilesPath(string directoryPath, FilterPagination paginationOptions);

    ValueTask<IList<StorageDirectory>> GetDirectoriesAsync(string directoryPath, FilterPagination paginationOptions);

    ValueTask<StorageDirectory?> GetByPathAsync(string directoryPath);
}