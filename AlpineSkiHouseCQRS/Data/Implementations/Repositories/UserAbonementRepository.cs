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
    public class UserAbonementRepository : IRepository<UserAbonementModel>
    {
        public UserAbonementRepository(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        private IApplicationDbContext _dbContext;

        public async void Create(UserAbonementModel item)
        {
            await _dbContext.UsersAbonements.AddAsync(item);
        }

        public async void Delete(Guid id)
        {
            UserAbonementModel userAbonement = await _dbContext.UsersAbonements.FindAsync(id);

            if (userAbonement == null)
            {
                throw new UserAbonementNotFoundException("Deleted user abonement not found");
            }

            _dbContext.UsersAbonements.Remove(userAbonement);
        }

        public async Task<UserAbonementModel> Get(Guid id)
        {
            return await _dbContext.UsersAbonements.FindAsync(id);
        }

        public IEnumerable<UserAbonementModel> GetAll()
        {
            return _dbContext.UsersAbonements;
        }

        public IEnumerable<UserAbonementModel> Find(Func<UserAbonementModel, bool> predicate)
        {
            return _dbContext.UsersAbonements.Where(predicate);
        }

        public void Update(UserAbonementModel item)
        {
            bool hasUserAbonement = _dbContext.UsersAbonements.Any(p => p.UserId == item.UserId && p.AbonementId == item.AbonementId);

            if (!hasUserAbonement)
            {
                throw new UserAbonementNotFoundException("Updated user abonement not found");
            }

            _dbContext.UsersAbonements.Update(item);
        }

        public void Save()
        {
            _dbContext.SaveAsync();
        }
    }
}
