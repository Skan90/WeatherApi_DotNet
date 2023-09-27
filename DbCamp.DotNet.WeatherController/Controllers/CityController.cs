using Microsoft.AspNetCore.Mvc;
using WeatherApiDomain.Entity.Dto;
using WeatherApiDomain.Interfaces.Services;

namespace WeatherApiController.Controllers
{
    [ApiController]
    [Route("api/v1/weather")]
    public class CityController : ControllerBase
    {
        private readonly ICityService _cityService;

        public CityController(ICityService cityService)
        {
            _cityService = cityService;
        }

        [HttpPost("register-city")]
        public async Task<IActionResult> Post([FromBody] CityRequestDto cityRequestDto)
        {
            var savedCity = await _cityService.SaveAsync(cityRequestDto);
            return CreatedAtAction(nameof(GetCityById), new { idCity = savedCity.IdCity }, savedCity);
        }

        [HttpGet("cities/all")]
        public async Task<IActionResult> GetAll()
        {
            List<CityResponseDto> cities = await _cityService.GetAllAsync();
            if (cities.Count == 0)
            {
                return NoContent();
            }
            return Ok(cities);
        }

        [HttpGet("cities/city-from-id/{idCity}")]
        public async Task<IActionResult> GetCityById(Guid idCity)
        {    
            var city = await _cityService.GetByIdAsync(idCity);
            
            if (city is null)
            {
                return NotFound("City with the given ID was not found.\n" +
                                "Check the Id and try again.");
            }
            
            return Ok(city);
        }

        [HttpGet("cities/city-id-from-name/{name}")]
        public async Task<IActionResult> GetIdByCityName(string name)
        {
            Guid? idCity = await _cityService.GetIdByCityName(name);
        
            if (idCity == Guid.Empty)
            {
                return NotFound("City with the given name was not found.\n" +
                                "Check the name and try again.");
            }
            return Ok(new {IdCity = idCity});
        }
    }
}