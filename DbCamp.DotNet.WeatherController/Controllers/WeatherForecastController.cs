using Microsoft.AspNetCore.Mvc;
using WeatherApiDomain.Entity.Dto;
using WeatherApiDomain.Interfaces.Services;
using WeatherApiService.Services;

namespace DbCamp.DotNet.WeatherController.Controllers;

[ApiController]
[Route("api/v1/weather")]
public class WeatherDataController : ControllerBase
{
    private readonly IWeatherForecastService _weatherForecastService;

    public WeatherDataController(IWeatherForecastService weatherForecastService)
    {
        _weatherForecastService = weatherForecastService;
    }
    
    [HttpPost("register")]
    public async Task<IActionResult> Post([FromBody] WeatherDataRequestDto weatherDataRequestDto)
    {
        var savedWeatherData = await _weatherForecastService.SaveAsync(weatherDataRequestDto);
        return CreatedAtAction(nameof(GetWeatherDataById), new { id = savedWeatherData.IdWeather }, savedWeatherData);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetWeatherDataById(Guid id)
    {
        var weatherForecast = await _weatherForecastService.GetByIdAsync(id);
        
        if (weatherForecast is null)
        {
            return NotFound("Weather forecast with the given ID was not found.\n" +
                            "Check the Id and try again.");
        }

        return Ok(weatherForecast);
    }
}
