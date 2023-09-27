using System.ComponentModel.DataAnnotations;

namespace WeatherApiDomain.Entity.Dto;

public class CityRequestDto
{
    [Key]
    public Guid IdCity { get; set; }
    [Required]
    [StringLength(100)]
    public string Name { get; set; }
}