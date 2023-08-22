using WeatherApi.Services;

namespace WeatherApi.Controllers;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/v1/weather")]
public class WeatherDataController : ControllerBase
{
    private readonly WeatherDataService _weatherDataService;

    public WeatherDataController(WeatherDataService weatherDataService)
    {
        _weatherDataService = weatherDataService;
    }

}
