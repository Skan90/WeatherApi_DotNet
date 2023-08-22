using System.ComponentModel.DataAnnotations;

namespace WeatherApi.Data.Dtos;

public class CityRequestDto
{
    [Key]
    public long IdCity { get; set; }
    [Required]
    [StringLength(100)]
    public string Name { get; set; }
}