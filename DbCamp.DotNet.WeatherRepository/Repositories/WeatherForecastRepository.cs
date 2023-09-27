using System.Data.Common;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using WeatherApi.Exceptions;
using WeatherApiDomain.Entity;
using WeatherApiDomain.Entity.Dto;
using WeatherApiDomain.Interfaces.Repositories;

namespace WeatherRepository.Repositories;


public class WeatherForecastRepository : IWeatherForecastRepository
{
    private readonly IMapper _mapper;
    private readonly WeatherContext _context;
    
    public WeatherForecastRepository(IMapper mapper, WeatherContext context)
    {
        _mapper = mapper;
        _context = context;
    }
    
    public async Task<WeatherForecast?> SaveAsync(WeatherForecast? weatherForecast)
    {
        try
        {
            EntityEntry<WeatherForecast> entityEntry = _context.WeatherDataEntities.Add(weatherForecast);
            await _context.SaveChangesAsync();
            var forecast = _mapper.Map<WeatherForecast>(entityEntry.Entity);
            return forecast;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public Task<List<WeatherForecast>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<WeatherForecast> GetAllAsyncWithId()
    {
        throw new NotImplementedException();
    }

    public async Task<WeatherForecast?> GetByIdAsync(Guid weatherId)
    {
        try
        {
            return await _context.WeatherDataEntities
                .FirstOrDefaultAsync(w => w.IdWeather == weatherId);
        }
        catch (DbException exception)
        {
            throw new DatabaseException($"An error occurred while retrieving weather data " +
                                        $"from the database with id {weatherId}. " +
                                        $"Please try again later.", exception);
        }
    }
}