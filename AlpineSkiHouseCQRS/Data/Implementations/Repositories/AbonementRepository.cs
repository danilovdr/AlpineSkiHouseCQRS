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
    public class AbonementRepository : IRepository<AbonementModel>
    {
        public AbonementRepository(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        private IApplicationDbContext _dbContext;

        public async void Create(AbonementModel item)
        {
            await _dbContext.Abonements.AddAsync(item);
        }

        public async void Delete(Guid id)
        {
            AbonementModel abonement = await _dbContext.Abonements.FindAsync(id);

            if (abonement == null)
            {
                throw new AbonementNotFoundException("Deleted abonement not found");
            }

            _dbContext.Abonements.Remove(abonement);
        }

        public async Task<AbonementModel> Get(Guid id)
        {
            return await _dbContext.Abonements.FindAsync(id);
        }

        public IEnumerable<AbonementModel> GetAll()
        {
            return _dbContext.Abonements;
        }

        public IEnumerable<AbonementModel> Find(Func<AbonementModel, bool> predicate)
        {
            return _dbContext.Abonements.Where(predicate);
        }

        public void Update(AbonementModel item)
        {
            bool hasAbonement = _dbContext.Abonements.Any(p => p.Id == item.Id);

            if (!hasAbonement)
            {
                throw new AbonementNotFoundException("Updated abonement not found");
            }

            _dbContext.Abonements.Update(item);
        }

    }
}
