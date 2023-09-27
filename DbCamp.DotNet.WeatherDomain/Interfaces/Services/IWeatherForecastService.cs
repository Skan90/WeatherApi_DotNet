using WeatherApiDomain.Entity.Dto;

namespace WeatherApiDomain.Interfaces.Services;

public interface IWeatherForecastService
{
    Task<WeatherDataRequestDto> SaveAsync(WeatherDataRequestDto weatherDataRequestDto);
    Task<List<WeatherDataRequestDto>> GetAllAsync();
    Task<WeatherDataRequestDto> GetAllAsyncWithId(); // TODO: Refactor this method
    Task<WeatherDataRequestDto?> GetByIdAsync(Guid weatherId);
}