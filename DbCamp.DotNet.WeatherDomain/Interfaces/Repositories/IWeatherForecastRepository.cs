using WeatherApiDomain.Entity;
using WeatherApiDomain.Entity.Dto;

namespace WeatherApiDomain.Interfaces.Repositories;

public interface IWeatherForecastRepository
{
    Task<WeatherForecast> SaveAsync(WeatherForecast weatherForecast);
    Task<List<WeatherForecast>> GetAllAsync();
    Task<WeatherForecast> GetAllAsyncWithId(); // TODO: Refactor this method
    Task<WeatherForecast?> GetByIdAsync(Guid weatherId);
}