using AlpineSkiHouseCQRS.Data.Interfaces;
using AlpineSkiHouseCQRS.Data.Interfaces.Repositories;
using AlpineSkiHouseCQRS.Data.Models;

namespace AlpineSkiHouseCQRS.Data.Implementations.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public IRepository<UserModel> UserRepository { get; set; }
        public IRepository<AbonementModel> AbonementRepository { get; set; }
        public IRepository<UserAbonementModel> UserAbonementRepository { get; set; }
        public IRepository<ZoneModel> ZoneRepository { get; set; }
        public IRepository<SlopeModel> SlopeRepository { get; set; }

        public UnitOfWork(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        private IApplicationDbContext _dbContext;

        public void Save()
        {
            _dbContext.SaveAsync();               
        }
    }
}
