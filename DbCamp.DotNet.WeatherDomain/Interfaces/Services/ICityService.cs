using WeatherApiDomain.Entity.Dto;

namespace WeatherApiDomain.Interfaces.Services;

public interface ICityService
{
    Task<CityRequestDto> SaveAsync(CityRequestDto cityRequestDto);
    Task<List<CityResponseDto>> GetAllAsync();
    Task<CityResponseDto> GetByIdAsync(Guid idCity);
    Task<Guid?> GetIdByCityName(string name);
}