using WeatherApi.Data.Models.Enums;

namespace WeatherApi.Data.Models;

using System;
using System.ComponentModel.DataAnnotations;

public class WeatherDataEntity
{
    [Key]
    public long IdWeatherData { get; set; }

    [Required]
    public long CityId { get; set; }

    public CityEntity City { get; set; }

    [Required]
    public DateTime Date { get; set; }

    [Required]
    public DayTimeEnum DayTimeEnum { get; set; }

    [Required]
    public NightTimeEnum NightTimeEnum { get; set; }

    [Range(-30, 70)]
    public int MaxTemperature { get; set; }

    [Range(-30, 70)]
    public int MinTemperature { get; set; }

    [Range(0, 100)]
    public int Precipitation { get; set; }

    [Range(0, 100)]
    public int Humidity { get; set; }

    [Range(0, 100)]
    public int WindSpeed { get; set; }
}
