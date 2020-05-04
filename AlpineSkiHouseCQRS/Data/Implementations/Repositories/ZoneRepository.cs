using AlpineSkiHouseCQRS.Data.Interfaces;
using AlpineSkiHouseCQRS.Data.Interfaces.Repositories;
using AlpineSkiHouseCQRS.Data.Models;
using AlpineSkiHouseCQRS.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlpineSkiHouseCQRS.Data.Implementations.Repositories
{
    public class ZoneRepository : IRepository<ZoneModel>
    {
        public ZoneRepository(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        private IApplicationDbContext _dbContext;

        public async void Create(ZoneModel item)
        {
            await _dbContext.Zones.AddAsync(item);
        }

        public async void Delete(Guid id)
        {
            ZoneModel zone = await _dbContext.Zones.FindAsync(id);

            if (zone == null)
            {
                throw new ZoneNotFoundException("Deleted zone not found");
            }

            _dbContext.Zones.Remove(zone);
        }

        public async Task<ZoneModel> Get(Guid id)
        {
            return await _dbContext.Zones.FindAsync(id);
        }

        public IEnumerable<ZoneModel> GetAll()
        {
            return _dbContext.Zones;
        }

        public IEnumerable<ZoneModel> Find(Func<ZoneModel, bool> predicate)
        {
            return _dbContext.Zones.Where(predicate);
        }

        public void Update(ZoneModel item)
        {
            bool hasZone = _dbContext.Zones.Any(p => p.Id == item.Id);

            if (!hasZone)
            {
                throw new ZoneNotFoundException("Updated zone not found");
            }

            _dbContext.Zones.Update(item);
        }

        public void Save()
        {
            _dbContext.SaveAsync();
        }
    }
}
