using WeatherApi.Data.Models;
using WeatherApi.Data.Models.Enums;

namespace WeatherApi.Data.Dtos;

public class WeatherDataRequestDTO
{
    public long IdWeatherData { get; set; }
    
    public CityEntity City { get; set; }
    
    public DateTime Date { get; set; }
    
    public DayTimeEnum DayTimeEnum { get; set; }
    
    public NightTimeEnum NightTimeEnum { get; set; }
    
    public int MaxTemperature { get; set; }
    
    public int MinTemperature { get; set; }
    
    public int Precipitation { get; set; }
    
    public int Humidity { get; set; }
    
    public int WindSpeed { get; set; }
}
