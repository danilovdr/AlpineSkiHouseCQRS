using AlpineSkiHouseCQRS.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace AlpineSkiHouseCQRS.Data.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<UserModel> Users { get; set; }
        DbSet<AbonementModel> Abonements { get; set; }
        DbSet<UserAbonementModel> UserAbonements { get; set; }
        DbSet<ZoneModel> Zones { get; set; }
        DbSet<SlopeModel> Slopes { get; set; }
    }
}
