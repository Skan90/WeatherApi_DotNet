using AutoMapper;
using WeatherApiDomain.Entity;
using WeatherApiDomain.Entity.Dto;
using WeatherApiDomain.Interfaces.Repositories;
using WeatherApiDomain.Interfaces.Services;
using WeatherRepository.Repositories;

namespace WeatherApiService.Services
{
    public class CityService : ICityService
    {
        private readonly IMapper _mapper;
        private readonly ICityRepository _cityRepository;

        public CityService(IMapper mapper, ICityRepository cityRepository)
        {
            _mapper = mapper;
            _cityRepository = cityRepository;
        }

        public async Task<CityRequestDto> SaveAsync(CityRequestDto cityRequestDto)
        {
            var cityEntity = _mapper.Map<CityEntity>(cityRequestDto);
            var savedEntity = await _cityRepository.AddAsync(cityEntity);
            return _mapper.Map<CityRequestDto>(savedEntity);
        }

        public async Task<List<CityResponseDto>> GetAllAsync()
        {
            var cities = await _cityRepository.GetAllAsync();
            return _mapper.Map<List<CityResponseDto>>(cities);
        }

        public async Task<Guid?> GetIdByCityName(string name)
        {
            Guid? idByCityNameAsync = await _cityRepository.GetIdByCityNameAsync(name);
            
            if (idByCityNameAsync == Guid.Empty)
            {
                throw new Exception(
                    "City with the given name was not found.\n" +
                    "Check the name and try again."
                );
            }
            
            return idByCityNameAsync;
        }

        public async Task<CityResponseDto> GetByIdAsync(Guid idCity)
        {
            CityEntity? city = await _cityRepository.GetByIdAsync(idCity);

            if (city == null)
            {
                throw new Exception(
                    "City with the given ID was not found.\n" +
                    "Check the Id and try again."
                );
            }

            return _mapper.Map<CityResponseDto>(city);
        }
    }
}