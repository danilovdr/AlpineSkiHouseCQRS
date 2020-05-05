using AlpineSkiHouseCQRS.Data.Interfaces;
using AlpineSkiHouseCQRS.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AlpineSkiHouseCQRS.Data.Implementations
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public DbSet<UserModel> Users { get; set; }
        public DbSet<IdentityRole<string>> Roles { get; set; }
        public DbSet<AbonementModel> Abonements { get; set; }
        public DbSet<UserAbonementModel> UsersAbonements { get; set; }
        public DbSet<ZoneModel> Zones { get; set; }
        public DbSet<SlopeModel> Slopes { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            Database.EnsureCreatedAsync();
        }

        public async void SaveAsync()
        {
            await SaveChangesAsync();
        }
    }
}
