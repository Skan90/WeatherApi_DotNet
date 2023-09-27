using AutoMapper;
using WeatherApi.Exceptions;
using WeatherApiDomain.Entity;
using WeatherApiDomain.Entity.Dto;
using WeatherApiDomain.Interfaces.Repositories;
using WeatherApiDomain.Interfaces.Services;
using WeatherRepository;

namespace WeatherApiService.Services;

public class WeatherForecastService : IWeatherForecastService
{
    private readonly IMapper _mapper;
    private readonly IWeatherForecastRepository _weatherForecastRepository;
    private readonly ICityRepository _cityRepository;

    public WeatherForecastService(IMapper mapper, ICityRepository cityRepository, IWeatherForecastRepository weatherForecastRepository)
    {
        _mapper = mapper;
        _weatherForecastRepository = weatherForecastRepository;
        _cityRepository = cityRepository;
    }
    public async Task<WeatherDataRequestDto> SaveAsync(WeatherDataRequestDto weatherDataRequestDto)
    {
        
        if (weatherDataRequestDto.CityId != Guid.Empty && (weatherDataRequestDto?.City?.IdCity == Guid.Empty && weatherDataRequestDto?.City.Name is null))
        {
            await _cityRepository.GetByIdAsync(weatherDataRequestDto.CityId!.Value);
        }
        else if ((weatherDataRequestDto.CityId == Guid.Empty && (weatherDataRequestDto.City.IdCity != Guid.Empty || weatherDataRequestDto.City.Name is not null)))
        {
            await _cityRepository.GetByIdAsync(weatherDataRequestDto!.CityId!.Value);
        } 
        
        if((weatherDataRequestDto?.City?.IdCity == Guid.Empty) && weatherDataRequestDto?.City?.Name is not null)
        {
            Guid? idByCityNameAsync = await _cityRepository.GetIdByCityNameAsync(weatherDataRequestDto.City.Name);
            if (idByCityNameAsync == Guid.Empty)
            {
                CityEntity cityEntity = _mapper.Map<CityEntity>(weatherDataRequestDto.City);
                CityEntity? savedCityEntity = await _cityRepository.AddAsync(cityEntity);
                if (cityEntity.IdCity == Guid.Empty)
                {
                    throw new CityNotFoundException("City with the given name was not found and could not be saved.\n" +
                                                    "Check the name and try again.");
                }
                weatherDataRequestDto.CityId = savedCityEntity!.IdCity;
            }
        }
        var weatherForecast = _mapper.Map<WeatherForecast>(weatherDataRequestDto);
        var savedEntity = _weatherForecastRepository.SaveAsync(weatherForecast);
        return _mapper.Map<WeatherDataRequestDto>(savedEntity);
        
    }

    public Task<List<WeatherDataRequestDto>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<WeatherDataRequestDto> GetAllAsyncWithId()
    {
        throw new NotImplementedException();
    }

    public async Task<WeatherDataRequestDto?> GetByIdAsync(Guid weatherId)
    {
        if (weatherId == Guid.Empty) throw new ArgumentOutOfRangeException(nameof(weatherId));

        WeatherForecast? weatherForecast = await _weatherForecastRepository.GetByIdAsync(weatherId);
        if (weatherForecast is null)
        {
            throw new Exception("WeatherData with the Id: " + weatherId + " was not found.\n" +
                                "Check the Id and try again.");
        }
        
        return _mapper.Map<WeatherDataRequestDto>(weatherForecast);
    }
}