﻿using AutoMapper;
using FileExplorer.Applicatoin.FIleStorege.Models;
using FileExplorer.Applicatoin.FIleStorege.Models.Storage;

namespace FileExplorer.Infrastructure.Common.MapperProfiles;

public class DriveProfile : Profile
{
    public DriveProfile()
    {
        CreateMap<DriveInfo, StorageDrive>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name.Substring(0, src.Name.IndexOf(":"))))
            .ForMember(dest => dest.Path, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Format, opt => opt.MapFrom(src => src.DriveFormat))
            .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.DriveFormat.ToString()))
            .ForMember(dest => dest.TotaleSpace, opt => opt.MapFrom(src => src.TotalSize))
            .ForMember(dest => dest.FreeSpace, opt => opt.MapFrom(src => src.TotalFreeSpace))
            .ForMember(dest => dest.UnavailableSpace, opt => opt.MapFrom(src => src.TotalFreeSpace - src.AvailableFreeSpace))
            .ForMember(dest => dest.UsedSpace, opt => opt.MapFrom(src => src.TotalSize - src.TotalFreeSpace));
    }
}