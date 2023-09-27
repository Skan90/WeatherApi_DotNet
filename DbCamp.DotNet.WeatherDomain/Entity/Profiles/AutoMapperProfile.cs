using AutoMapper;
using WeatherApiDomain.Entity.Dto;

namespace WeatherApiDomain.Entity.Profiles;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile() 
    {
        CreateMap<CityRequestDto, CityEntity>();
        CreateMap<CityEntity, CityRequestDto>();
        CreateMap<CityResponseDto, CityEntity>();
        CreateMap<CityEntity, CityResponseDto>();
        CreateMap<WeatherForecast, WeatherDataRequestDto>();
        CreateMap<WeatherDataRequestDto, WeatherForecast>();
    }
}