using AutoMapper;
using WeatherApi.Data.Dtos;
using WeatherApi.Data.Models;

namespace WeatherApi.Data.Profiles;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<CityRequestDto, CityEntity>();
        CreateMap<CityEntity, CityRequestDto>();
        CreateMap<CityResponseDto, CityEntity>();
        CreateMap<CityEntity, CityResponseDto>();
        CreateMap<WeatherDataEntity, WeatherDataRequestDTO>();
        CreateMap<WeatherDataRequestDTO, WeatherDataEntity>();
    }
}