using AutoMapper;
using FileExplorer.Applicatoin.Common.Filtering;
using FileExplorer.Applicatoin.Common.Querying.Extensions;
using FileExplorer.Applicatoin.FIleStorege.Broker;
using FileExplorer.Applicatoin.FIleStorege.Models.Storage;
using FileExplorer.Applicatoin.FIleStorege.Services;

namespace FileExplorer.Infrastructure.FileStorage.Services;

public class DirectoryService : IDirectoryService
{
    private readonly IDirectoryBroker _broker;
    private readonly IMapper _mapper;

    public DirectoryService(IDirectoryBroker broker, IMapper mapper)
    {
        _broker = broker;
        _mapper = mapper;
    }

    public IEnumerable<string> GetDirectoriesPath(string directoryPath, FilterPagination paginationOptions)
        => _broker.GetDirectoriesPath(directoryPath).ApplyPagination(paginationOptions);

    public IEnumerable<string> GetFilesPath(string directoryPath, FilterPagination paginationOptions)
        => _broker.GetFilesPath(directoryPath).ApplyPagination(paginationOptions);

    public async ValueTask<IList<StorageDirectory>> GetDirectoriesAsync(string directoryPath, FilterPagination paginationOptions)
    {
        if (string.IsNullOrWhiteSpace(directoryPath))
            throw new ArgumentNullException(nameof(directoryPath));

        var directories = await Task.Run(() =>
            _broker.GetDirectories(directoryPath).ApplyPagination(paginationOptions).ToList());

        return directories;
    }

    public ValueTask<StorageDirectory?> GetByPathAsync(string directoryPath)
    {
        if (string.IsNullOrWhiteSpace(directoryPath))
            throw new ArgumentNullException(nameof(directoryPath));

        return new ValueTask<StorageDirectory?>(_broker.GetByPathAsync(directoryPath));
    }
}