using FileExplorer.Applicatoin.Common.Filtering;
using FileExplorer.Applicatoin.FIleStorege.Models.Filtering;
using FileExplorer.Applicatoin.FIleStorege.Models.Storage;

namespace FileExplorer.Applicatoin.FIleStorege.Services;

public interface IFileService
{
    ValueTask<IList<StorageFile>> GetFilesByPathAsync(IEnumerable<string> filesPath);

    ValueTask<StorageFile> GetFileByPathAsync(string filePath);

    IEnumerable<StorageFilesSummary> getFilesSummary(IEnumerable<StorageFile> files);

    StorageFileType GetFileType(string filePath);

}