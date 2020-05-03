using AlpineSkiHouseCQRS.Data.Interfaces;
using AlpineSkiHouseCQRS.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace AlpineSkiHouseCQRS.Data.Implementations
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public DbSet<UserModel> Users { get; set; }
        public DbSet<AbonementModel> Abonements { get; set; }
        public DbSet<UserAbonementModel> UsersAbonements { get; set; }
        public DbSet<ZoneModel> Zones { get; set; }
        public DbSet<SlopeModel> Slopes { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            Database.EnsureCreatedAsync();
        }

        public void Save()
        {
            SaveChangesAsync();
        }
    }
}
