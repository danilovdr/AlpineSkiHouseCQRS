using AlpineSkiHouseCQRS.Data.Interfaces;
using AlpineSkiHouseCQRS.Data.Interfaces.Repositories;
using AlpineSkiHouseCQRS.Data.Models;
using System.Threading.Tasks;

namespace AlpineSkiHouseCQRS.Data.Implementations.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public IRepository<UserModel> UserRepository { get; }
        public IRepository<AbonementModel> AbonementRepository { get; }
        public IRepository<UserAbonementModel> UserAbonementRepository { get; }
        public IRepository<ZoneModel> ZoneRepository { get; }
        public IRepository<SlopeModel> SlopeRepository { get; }

        public UnitOfWork(IApplicationDbContext dbContext, IRepository<UserModel> userRepository,
            IRepository<AbonementModel> abonementRepository, IRepository<UserAbonementModel> userAbonementRepository,
            IRepository<ZoneModel> zoneRepository, IRepository<SlopeModel> slopeRepository)
        {
            _dbContext = dbContext;
            UserRepository = userRepository;
            AbonementRepository = abonementRepository;
            UserAbonementRepository = userAbonementRepository;
            ZoneRepository = zoneRepository;
            SlopeRepository = slopeRepository;
        }

        private IApplicationDbContext _dbContext;

        public async Task Save()
        {
            await _dbContext.SaveAsync();
        }
    }
}
