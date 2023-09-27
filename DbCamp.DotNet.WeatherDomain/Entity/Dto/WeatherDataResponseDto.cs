using WeatherApiDomain.Enums;

namespace WeatherApiDomain.Entity.Dto;

public class WeatherDataResponseDto
{
    public Guid IdWeather { get; set; }

    public Guid CityId { get; set; }

    public CityResponseDto? City { get; set; }

    public DateTime Date { get; set; }

    public DayTimeEnum DayTimeEnum { get; set; }

    public NightTimeEnum NightTimeEnum { get; set; }

    public int MaxTemperature { get; set; }

    public int MinTemperature { get; set; }

    public int Precipitation { get; set; }

    public int Humidity { get; set; }

    public int WindSpeed { get; set; }
}