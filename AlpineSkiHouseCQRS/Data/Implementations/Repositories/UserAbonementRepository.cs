using AlpineSkiHouseCQRS.Data.Interfaces;
using AlpineSkiHouseCQRS.Data.Interfaces.Repositories;
using AlpineSkiHouseCQRS.Data.Models;
using AlpineSkiHouseCQRS.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AlpineSkiHouseCQRS.Data.Implementations.Repositories
{
    public class UserAbonementRepository : IRepository<UserAbonementModel>
    {
        public UserAbonementRepository(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        private IApplicationDbContext _dbContext;

        public void Create(UserAbonementModel item)
        {
            _dbContext.UsersAbonements.Add(item);
        }

        public void Delete(Guid id)
        {
            UserAbonementModel userAbonement = _dbContext.UsersAbonements.Find(id);

            if (userAbonement == null)
            {
                throw new UserAbonementNotFoundException("Deleted user abonement not found");
            }

            _dbContext.UsersAbonements.Remove(userAbonement);
        }

        public UserAbonementModel Get(Guid id)
        {
            return _dbContext.UsersAbonements.Find(id);
        }

        public IEnumerable<UserAbonementModel> GetAll()
        {
            return _dbContext.UsersAbonements;
        }

        public void Update(UserAbonementModel item)
        {
            bool hasUserAbonement = _dbContext.UsersAbonements.Any(p => p.Id == item.Id);

            if (!hasUserAbonement)
            {
                throw new UserAbonementNotFoundException("Updated user abonement not found");
            }

            _dbContext.UsersAbonements.Update(item);
        }

        public void Save()
        {
            _dbContext.Save();
        }
    }
}
