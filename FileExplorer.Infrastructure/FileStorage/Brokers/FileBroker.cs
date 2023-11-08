using AutoMapper;
using FileExplorer.Applicatoin.FIleStorege.Broker;
using FileExplorer.Applicatoin.FIleStorege.Models.Storage;

namespace FileExplorer.Infrastructure.FileStorage.Brokers;

public class FileBroker : IFileBroker
{
    private readonly IMapper _mapper;

    public FileBroker(IMapper mapper)
    {
        _mapper = mapper;
    }
    public StorageFile GetByPath(string filePath)
    {
        return _mapper.Map<StorageFile>(new FileInfo(filePath));
    }
}