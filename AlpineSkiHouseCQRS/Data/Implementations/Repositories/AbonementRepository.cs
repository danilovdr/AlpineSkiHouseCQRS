using AlpineSkiHouseCQRS.Data.Interfaces;
using AlpineSkiHouseCQRS.Data.Interfaces.Repositories;
using AlpineSkiHouseCQRS.Data.Models;
using AlpineSkiHouseCQRS.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AlpineSkiHouseCQRS.Data.Implementations.Repositories
{
    public class AbonementRepository : IRepository<AbonementModel>
    {
        public AbonementRepository(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        private IApplicationDbContext _dbContext;

        public void Create(AbonementModel item)
        {
            _dbContext.Abonements.Add(item);
        }

        public void Delete(Guid id)
        {
            AbonementModel abonement = _dbContext.Abonements.Find(id);

            if (abonement == null)
            {
                throw new AbonementNotFoundException("Deleted abonement not found");
            }

            _dbContext.Abonements.Remove(abonement);
        }

        public AbonementModel Get(Guid id)
        {
            return _dbContext.Abonements.Find(id);
        }

        public IEnumerable<AbonementModel> GetAll()
        {
            return _dbContext.Abonements;
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

        public void Save()
        {
            _dbContext.Save();
        }
    }
}
