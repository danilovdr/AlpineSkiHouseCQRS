using AlpineSkiHouseCQRS.Data.Interfaces;
using AlpineSkiHouseCQRS.Data.Interfaces.Repositories;
using AlpineSkiHouseCQRS.Data.Models;
using AlpineSkiHouseCQRS.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AlpineSkiHouseCQRS.Data.Implementations.Repositories
{
    public class SlopeRepository : IRepository<SlopeModel>
    {
        public SlopeRepository(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        private IApplicationDbContext _dbContext;

        public void Create(SlopeModel item)
        {
            _dbContext.Slopes.Add(item);
        }

        public void Delete(Guid id)
        {
            SlopeModel slope = _dbContext.Slopes.Find(id);

            if (slope == null)
            {
                throw new SlopeNotFoundException("Deleted slope not found");
            }

            _dbContext.Slopes.Remove(slope);
        }

        public SlopeModel Get(Guid id)
        {
            return _dbContext.Slopes.Find(id);
        }

        public IEnumerable<SlopeModel> GetAll()
        {
            return _dbContext.Slopes;
        }

        public IEnumerable<SlopeModel> Find(Func<SlopeModel, bool> predicate)
        {
            return _dbContext.Slopes.Where(predicate);
        }

        public void Update(SlopeModel item)
        {
            bool hasSlope = _dbContext.Slopes.Any(p => p.Id == item.Id);

            if (!hasSlope)
            {
                throw new SlopeNotFoundException("Updated slope not found");
            }

            _dbContext.Slopes.Update(item);
        }

        public void Save()
        {
            _dbContext.Save();
        }
    }
}
