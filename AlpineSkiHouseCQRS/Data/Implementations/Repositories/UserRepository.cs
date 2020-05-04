using AlpineSkiHouseCQRS.Data.Interfaces;
using AlpineSkiHouseCQRS.Data.Interfaces.Repositories;
using AlpineSkiHouseCQRS.Data.Models;
using AlpineSkiHouseCQRS.Exceptions;
using System.Linq;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;

namespace AlpineSkiHouseCQRS.Data.Implementations.Repositories
{
    public class UserRepository : IRepository<UserModel>
    {
        public UserRepository(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        private IApplicationDbContext _dbContext;

        public async void Create(UserModel item)
        {
            await _dbContext.Users.AddAsync(item);
        }

        public async void Delete(Guid id)
        {
            UserModel user = await _dbContext.Users.FindAsync(id);

            if (user == null)
            {
                throw new UserNotFoundException("Deleted user not found");
            }

            _dbContext.Users.Remove(user);
        }

        public async Task<UserModel> Get(Guid id)
        {
            return await _dbContext.Users.FindAsync(id);
        }

        public IEnumerable<UserModel> GetAll()
        {
            return _dbContext.Users;
        }

        public IEnumerable<UserModel> Find(Func<UserModel, bool> predicate)
        {
            return _dbContext.Users.Where(predicate);
        }

        public void Update(UserModel item)
        {
            bool hasUser = _dbContext.Users.Any(p => p.Id == item.Id);

            if (!hasUser)
            {
                throw new UserNotFoundException("Updated user not found");
            }

            _dbContext.Users.Update(item);
        }

        public void Save()
        {
            _dbContext.SaveAsync();
        }
    }
}
