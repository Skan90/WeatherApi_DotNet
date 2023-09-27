using System.ComponentModel.DataAnnotations;
using WeatherApiDomain.Enums;

namespace WeatherApiDomain.Entity.Dto;

public class WeatherDataRequestDto
{
    public Guid IdWeather { get; set; }

    public Guid? CityId { get; set; }

    public CityRequestDto? City { get; set; }

    [Required(ErrorMessage = "Date is required.")]
    public DateTime Date { get; set; }

    [Required(ErrorMessage = "DayTimeEnum is required.")]
    public DayTimeEnum DayTimeEnum { get; set; }

    [Required(ErrorMessage = "NightTimeEnum is required.")]
    public NightTimeEnum NightTimeEnum { get; set; }

    [Required(ErrorMessage = "MaxTemperature is required.")]
    [Range(-30, 70, ErrorMessage = "MaxTemperature must be between -30 and 70.")]
    public int MaxTemperature { get; set; }

    [Required(ErrorMessage = "MinTemperature is required.")]
    [Range(-30, 70, ErrorMessage = "MinTemperature must be between -30 and 70.")]
    public int MinTemperature { get; set; }

    [Range(0, 100, ErrorMessage = "Precipitation must be between 0 and 100.")]
    public int Precipitation { get; set; }

    [Range(0, 100, ErrorMessage = "Humidity must be between 0 and 100.")]
    public int Humidity { get; set; }

    [Range(0, 100, ErrorMessage = "WindSpeed must be between 0 and 100.")]
    public int WindSpeed { get; set; }
}