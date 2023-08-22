namespace WeatherApi.Data.Models;
using System.ComponentModel.DataAnnotations;

public class CityEntity
{
    [Key]
    public long IdCity { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; }

    public List<WeatherDataEntity> WeatherDataList { get; set; }
}
