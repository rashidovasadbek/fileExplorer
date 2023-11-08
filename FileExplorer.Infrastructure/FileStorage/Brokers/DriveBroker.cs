using AutoMapper;
using FileExplorer.Applicatoin.FIleStorege.Broker;
using FileExplorer.Applicatoin.FIleStorege.Models;
using FileExplorer.Applicatoin.FIleStorege.Models.Storage;

namespace FileExplorer.Infrastructure.FileStorage.Brokers;

public class DriveBroker : IDriveBroker
{
    private readonly IMapper _mapper;

    public DriveBroker(IMapper mapper)
    {
        _mapper = mapper;
    }

    public IEnumerable<StorageDrive> Get()
    {
        return DriveInfo
            .GetDrives()
            .Select(driveInfo => _mapper.Map<StorageDrive>(driveInfo))
            .AsQueryable();

    }
}