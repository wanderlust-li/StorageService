using AutoMapper;
using Infrastructure.Application.DTO;
using StorageService.Domain.Entities;

namespace Infrastructure.Application;

public class MappingConfig : Profile
{
    public MappingConfig()
    {
        CreateMap<Advertisement, AdvertisementDTO>();
        CreateMap<AdvertisementDTO, Advertisement>();
        
        CreateMap<Advertisement, CreateAdvertisementDTO>().ReverseMap();
        
    }
}