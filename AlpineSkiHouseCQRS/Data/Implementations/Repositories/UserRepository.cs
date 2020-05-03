using AlpineSkiHouseCQRS.Data.Interfaces;
using AlpineSkiHouseCQRS.Data.Interfaces.Repositories;
using AlpineSkiHouseCQRS.Data.Models;
using AlpineSkiHouseCQRS.Exceptions;
using System.Linq;
using System.Collections.Generic;
using System;

namespace AlpineSkiHouseCQRS.Data.Implementations.Repositories
{
    public class UserRepository : IRepository<UserModel>
    {
        public UserRepository(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        private IApplicationDbContext _dbContext;

        public void Create(UserModel item)
        {
            _dbContext.Users.Add(item);
        }

        public void Delete(Guid id)
        {
            UserModel user = _dbContext.Users.Find(id);

            if (user == null)
            {
                throw new UserNotFoundException("Deleted user not found");
            }

            _dbContext.Users.Remove(user);
        }

        public UserModel Get(Guid id)
        {
            return _dbContext.Users.Find(id);
        }

        public IEnumerable<UserModel> GetAll()
        {
            return _dbContext.Users;
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
            _dbContext.Save();
        }
    }
}
