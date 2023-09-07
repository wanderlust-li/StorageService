using AutoMapper;
using StorageService.Application.DTO;
using StorageService.Domain.Entities;

namespace StorageService.Application;

public class MappingConfig : Profile
{
    public MappingConfig()
    {
        CreateMap<Advertisement, AdvertisementDTO>();
        CreateMap<AdvertisementDTO, Advertisement>();
        
        CreateMap<Advertisement, CreateAdvertisementDTO>().ReverseMap();
        
    }
}