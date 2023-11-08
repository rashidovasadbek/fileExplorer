using FileExplorer.Applicatoin.Common.Filtering;
using FileExplorer.Applicatoin.FIleStorege.Broker;
using FileExplorer.Applicatoin.FIleStorege.Models.Filtering;
using FileExplorer.Applicatoin.FIleStorege.Models.Settings;
using FileExplorer.Applicatoin.FIleStorege.Models.Storage;
using FileExplorer.Applicatoin.FIleStorege.Services;
using Microsoft.Extensions.Options;

namespace FileExplorer.Infrastructure.FileStorage.Services;

public class FileService : IFileService
{
    private readonly FileStorageSettings _fileStorageSettings;
    private readonly FileFilterSettings _fileFilterSettings;
    private readonly IFileBroker _filebroker;

    public FileService(IOptions<FileStorageSettings> fileStorageSettings, IOptions<FileFilterSettings> fileFilterSettings, IFileBroker filebroker)
    {
        _fileStorageSettings = fileStorageSettings.Value;
        _fileFilterSettings = fileFilterSettings.Value;
        _filebroker = filebroker;
    }
    

    public async ValueTask<IList<StorageFile>> GetFilesByPathAsync(IEnumerable<string> filesPath)
    {
        var files = await Task.Run(() =>
        {
            return filesPath.Select(filesPath => _filebroker.GetByPath(filesPath)).ToList();
        });

        return files;
    }

    public ValueTask<StorageFile> GetFileByPathAsync(string filePath)
        => !string.IsNullOrWhiteSpace(filePath)
            ? new ValueTask<StorageFile>(_filebroker.GetByPath(filePath))
            : throw new ArgumentNullException();

    public IEnumerable<StorageFilesSummary> getFilesSummary(IEnumerable<StorageFile> files)
    {
        var filesType = files.Select(file => (File: file, Type: GetFileType(file.Path)));
        return filesType
            .GroupBy(file => file.Type)
            .Select(filesGroup => new StorageFilesSummary
            {
                FileType = filesGroup.Key,
                DisplayName = _fileFilterSettings.FileExtension.FirstOrDefault(extension => extension.FileType == filesGroup.Key)?.DisplayName ??
                              "Other files",
                Count = filesGroup.Count(),
                Size = filesGroup.Sum(file => file.File.Size),
                ImageUrl = _fileFilterSettings.FileExtension.FirstOrDefault(extension => extension.FileType == filesGroup.Key)?.ImageUrl ??
                           _fileStorageSettings.FileImageUrl
            });
    }

    public StorageFileType GetFileType(string filePath)
    {
        var fileExtensions = Path.GetExtension(filePath).TrimStart('.');
        var matchedFileType =
            _fileFilterSettings.FileExtension.FirstOrDefault(fileExtension =>
                fileExtension.Extensions.Contains(fileExtensions));
        return matchedFileType?.FileType ?? StorageFileType.Other;
    }
}