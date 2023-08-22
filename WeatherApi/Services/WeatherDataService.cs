using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WeatherApi.Data.Dtos;
using WeatherApi.Data.Models;

namespace WeatherApi.Services
{
    public class WeatherDataService
    {
        private readonly WeatherContext _context;
        private readonly IMapper _mapper;
        private readonly CityService _cityService;

        public WeatherDataService(WeatherContext context, IMapper mapper, CityService cityService)
        {
            _context = context;
            _mapper = mapper;
            _cityService = cityService;
        }

        public async Task<WeatherDataEntity> SaveAsync(WeatherDataEntity weatherDataEntity)
        {
            var allCities = await _cityService.GetAllAsync();
            var cityName = weatherDataEntity.City.Name;

            var cityExists = allCities.Any(city => city.Name.Equals(cityName, StringComparison.OrdinalIgnoreCase));

            if (!cityExists)
            {
                var newCity = new CityEntity { Name = cityName };
                // var savedCity = await _cityService.SaveAsync(newCity);
                // weatherDataEntity.City.IdCity = savedCity.IdCity;
            }
            else
            {
                var existingCity = allCities.First(city => city.Name.Equals(cityName, StringComparison.OrdinalIgnoreCase));
                // weatherDataEntity.City.IdCity = existingCity.IdCity;
            }

            _context.WeatherDataEntities.Add(weatherDataEntity);
            await _context.SaveChangesAsync();

            return weatherDataEntity;
        }

        public async Task<List<WeatherDataEntity>> GetAllAsync()
        {
            return await _context.WeatherDataEntities.OrderByDescending(w => w.Date).ToListAsync();
        }

    }
}