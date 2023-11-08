using AutoMapper;
using FileExplorer.Applicatoin.FIleStorege.Models.Storage;
using FileExplorer.Models.Dtos;

namespace FileExplorer.Common;

public class DriveProfile : Profile
{
    public DriveProfile()
    {
        CreateMap<StorageDrive, StorageDirectoryDto>();
        CreateMap<StorageDriveDto, StorageDrive>();
    } 
}