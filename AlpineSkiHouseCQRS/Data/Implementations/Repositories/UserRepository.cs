using AlpineSkiHouseCQRS.Data.Interfaces;
using AlpineSkiHouseCQRS.Data.Interfaces.Repositories;
using AlpineSkiHouseCQRS.Data.Models;
using System;
using System.Collections.Generic;

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

        public void Delete(int id)
        {
            UserModel user = 
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public UserModel Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(UserModel item)
        {
            throw new NotImplementedException();
        }
    }
}
