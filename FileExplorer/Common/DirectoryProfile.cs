using AutoMapper;
using FileExplorer.Applicatoin.FIleStorege.Models.Storage;
using FileExplorer.Models.Dtos;

namespace FileExplorer.Common;

public class DirectoryProfile : Profile
{
    public DirectoryProfile()
    {
        CreateMap<StorageDirectory, StorageDirectoryDto>();
        CreateMap<StorageDirectoryDto, StorageDirectory>();
    }
}