using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeatherApiDomain.Entity;

public class CityEntity
{
    [Key]
    public Guid IdCity { get; set; }

    [Required, MaxLength(100)]
    public string Name { get; set; } = string.Empty;
    
    [ForeignKey("CityId")]
    public List<WeatherForecast> WeatherForecastList { get; set; } = new List<WeatherForecast>();
}