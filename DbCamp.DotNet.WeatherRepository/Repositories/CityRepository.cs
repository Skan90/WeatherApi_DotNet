using System.Data.Common;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using WeatherApi.Exceptions;
using WeatherApiDomain.Entity;
using WeatherApiDomain.Interfaces.Repositories;
using static Microsoft.EntityFrameworkCore.EF;

namespace WeatherRepository.Repositories
{
    public class CityRepository : ICityRepository
    {
        private readonly WeatherContext _context;
        private readonly IMapper _mapper;

        public CityRepository(WeatherContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CityEntity?> AddAsync(CityEntity? cityEntity)
        {
            try
            {        
                if (cityEntity != null)
                {
                    cityEntity.Name = cityEntity.Name.ToLower();
                }
                EntityEntry<CityEntity?> entityEntry = await _context.CityEntities.AddAsync(cityEntity);
                await _context.SaveChangesAsync();
                return _mapper.Map<CityEntity>(entityEntry.Entity);
            }
            catch (DbUpdateException)
            {
                throw new DatabaseException("An error occurred while adding the city to the database. Please try again later.");
            }
        }

        public async Task<List<CityEntity?>> GetAllAsync()
        {
            try
            {
                Task<List<CityEntity?>> listAsync = _context.CityEntities.ToListAsync();
                return await listAsync;
            }
            catch (DbException dbException)
            {
                throw new DatabaseException("An error occurred while retrieving cities from the database. Please try again later.", dbException);
            }
        }

        public async Task<CityEntity?> GetByIdAsync(Guid idCity)
        {
            try
            {
                return await _context.CityEntities.FirstOrDefaultAsync(c => c.IdCity == idCity);
            }
            catch (DbException exception)
            {
                throw new DatabaseException($"An error occurred while retrieving the city with Id: {idCity}. " +
                                            $"Please try again later.", exception);
            }
        }
        
        public async Task<Guid?> GetIdByCityNameAsync(string name)
        {
            try
            {
                CityEntity? cityEntity = await _context.CityEntities
                    .Where(c => Functions.ILike(c.Name, name))
                    .FirstOrDefaultAsync();

                if (cityEntity?.IdCity == Guid.Empty)
                {
                    return Guid.Empty;
                }
                
                return cityEntity!.IdCity;
            }
            catch (DbException exception)
            {
                throw new DatabaseException($"An error occurred while retrieving the city by the given name. Please try again later.", exception);
            }
        }
    }
}