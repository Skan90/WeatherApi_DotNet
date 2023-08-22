using System.ComponentModel.DataAnnotations;

namespace WeatherApi.Data.Dtos;

public class CityResponseDto
{
    [StringLength(100)]
    public string Name { get; set; }
}