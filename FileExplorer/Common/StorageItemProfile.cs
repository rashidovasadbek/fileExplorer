using AutoMapper;
using FileExplorer.Applicatoin.FIleStorege.Models.Storage;
using FileExplorer.Models.Dtos;

namespace FileExplorer.Common;

public class StorageItemProfile : Profile
{
    public StorageItemProfile()
    {
        CreateMap<IStorageEntry, IStorageItemDto>();
        CreateMap<IStorageItemDto, IStorageEntry>();
    }
}