using AutoMapper;
using FileExplorer.Applicatoin.FIleStorege.Models.Storage;
using FileExplorer.Models.Dtos;

namespace FileExplorer.Common;

public class FileProfile : Profile
{
    public FileProfile()
    {
        CreateMap<StorageFile, StorageFileDto>();
        CreateMap<StorageFileDto, StorageFile>();
    }
}