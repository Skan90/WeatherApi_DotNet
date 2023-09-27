using WeatherApiDomain.Entity;

namespace WeatherApiDomain.Interfaces.Repositories;

public interface ICityRepository
{
    Task<CityEntity?> AddAsync(CityEntity? cityEntity);
    Task<List<CityEntity?>> GetAllAsync();
    Task<CityEntity?> GetByIdAsync(Guid idCity);
    Task<Guid?> GetIdByCityNameAsync(string name);
}