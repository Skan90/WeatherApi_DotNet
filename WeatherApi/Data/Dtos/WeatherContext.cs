using Microsoft.EntityFrameworkCore;
using WeatherApi.Data.Models;

namespace WeatherApi.Data.Dtos
{
    public class WeatherContext : DbContext
    {
        public WeatherContext(DbContextOptions<WeatherContext> options) 
            : base(options)
        {
        }

        public DbSet<WeatherDataEntity> WeatherDataEntities { get; set; }
        public DbSet<CityEntity> CityEntities { get; set; }
    }
}