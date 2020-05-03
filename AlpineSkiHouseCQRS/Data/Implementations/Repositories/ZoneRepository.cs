using AlpineSkiHouseCQRS.Data.Interfaces;
using AlpineSkiHouseCQRS.Data.Interfaces.Repositories;
using AlpineSkiHouseCQRS.Data.Models;
using AlpineSkiHouseCQRS.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AlpineSkiHouseCQRS.Data.Implementations.Repositories
{
    public class ZoneRepository : IRepository<ZoneModel>
    {
        public ZoneRepository(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        private IApplicationDbContext _dbContext;

        public void Create(ZoneModel item)
        {
            _dbContext.Zones.Add(item);
        }

        public void Delete(Guid id)
        {
            ZoneModel zone = _dbContext.Zones.Find(id);

            if (zone == null)
            {
                throw new ZoneNotFoundException("Deleted zone not found");
            }

            _dbContext.Zones.Remove(zone);
        }

        public ZoneModel Get(Guid id)
        {
            return _dbContext.Zones.Find(id);
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
            _dbContext.Save();
        }
    }
}
