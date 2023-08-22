using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WeatherApi.Data.Dtos;
using WeatherApi.Data.Models;

namespace WeatherApi.Services
{
    public class CityService
    {
        private readonly WeatherContext _context;
        private readonly IMapper _mapper;

        public CityService(WeatherContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CityRequestDto> SaveAsync(CityRequestDto cityRequestDto)
        {
            CityEntity cityEntity = _mapper.Map<CityEntity>(cityRequestDto);
            var entityEntry = _context.CityEntities.Add(cityEntity);
            await _context.SaveChangesAsync();
            CityRequestDto cityEntityDto = _mapper.Map<CityRequestDto>(entityEntry.Entity);
            return cityEntityDto;
        }

        public async Task<List<CityResponseDto>> GetAllAsync()
        {
            var cities = await _context.CityEntities.ToListAsync();
            return _mapper.Map<List<CityResponseDto>>(cities);
        }

        public async Task<CityResponseDto> GetByIdAsync(long idCity)
        {
            var city = await _context.CityEntities.FirstOrDefaultAsync(c => c.IdCity == idCity);
            return _mapper.Map<CityResponseDto>(city);
        }
    }
}