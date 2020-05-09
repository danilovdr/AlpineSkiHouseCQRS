using AlpineSkiHouseCQRS.Data.Models;

namespace AlpineSkiHouseCQRS.Data.Interfaces.Repositories
{
    public interface IUnitOfWork
    {
        public IRepository<UserModel> UserRepository { get; }
        public IRepository<AbonementModel> AbonementRepository { get; }
        public IRepository<UserAbonementModel> UserAbonementRepository { get; }
        public IRepository<ZoneModel> ZoneRepository { get; }
        public IRepository<SlopeModel> SlopeRepository { get; }

        void Save();
    }
}
