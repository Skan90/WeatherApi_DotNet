using System.ComponentModel.DataAnnotations;

namespace WeatherApiDomain.Entity.Dto;

public class CityResponseDto
{
    [StringLength(100)]
    public string Name { get; set; }
}