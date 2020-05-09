using AlpineSkiHouseCQRS.Data.Models;

namespace AlpineSkiHouseCQRS.Data.Interfaces.Repositories
{
    public interface IUnitOfWork
    {
        public IRepository<UserModel> UserRepository { get; set; }
        public IRepository<AbonementModel> AbonementRepository { get; set; }
        public IRepository<UserAbonementModel> UserAbonementRepository { get; set; }
        public IRepository<ZoneModel> ZoneRepository { get; set; }
        public IRepository<SlopeModel> SlopeRepository { get; set; }

        void Save();
    }
}
