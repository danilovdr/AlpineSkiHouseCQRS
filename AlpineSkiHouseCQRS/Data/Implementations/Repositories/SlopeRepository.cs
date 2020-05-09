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
    public class SlopeRepository : IRepository<SlopeModel>
    {
        public SlopeRepository(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        private IApplicationDbContext _dbContext;

        public async void Create(SlopeModel item)
        {
            await _dbContext.Slopes.AddAsync(item);
        }

        public async void Delete(Guid id)
        {
            SlopeModel slope = await _dbContext.Slopes.FindAsync(id);

            if (slope == null)
            {
                throw new SlopeNotFoundException("Deleted slope not found");
            }

            _dbContext.Slopes.Remove(slope);
        }

        public async Task<SlopeModel> Get(Guid id)
        {
            return await _dbContext.Slopes.FindAsync(id);
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
    }
}
