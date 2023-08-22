using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WeatherApi.Data.Dtos;
using WeatherApi.Services;

namespace WeatherApi.Controllers
{
    [ApiController]
    [Route("api/v1/weather")]
    public class CityController : ControllerBase
    {
        private readonly CityService _cityService;

        public CityController(CityService cityService)
        {
            _cityService = cityService;
        }

        [HttpPost("register-city")]
        public async Task<IActionResult> Post([FromBody] CityRequestDto cityRequestDto)
        {
            var savedCity = await _cityService.SaveAsync(cityRequestDto);
            return CreatedAtAction(nameof(GetCityById), new { id = savedCity.IdCity }, savedCity);
        }

        [HttpGet("cities/all")]
        public async Task<IActionResult> GetAll()
        {
            var cities = await _cityService.GetAllAsync();
            return Ok(cities);
        }

        [HttpGet("cities/{id}")]
        public async Task<IActionResult> GetCityById(long id)
        {
            var city = await _cityService.GetByIdAsync(id);

            if (city == null)
            {
                return NotFound();
            }

            return Ok(city);
        }
    }
}