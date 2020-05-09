using AlpineSkiHouseCQRS.Data.Interfaces;
using AlpineSkiHouseCQRS.Data.Models;
using AlpineSkiHouseCQRS.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

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
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserAbonementModel>()
                .ToTable("UserAbonement")
                .HasKey(p => new { p.UserId, p.AbonementId });

            modelBuilder.Entity<UserAbonementModel>()
                .HasOne(p => p.User)
                .WithMany(p => p.UserAbonement)
                .HasForeignKey(p => p.UserId);

            modelBuilder.Entity<UserAbonementModel>()
                .HasOne(p => p.Abonement)
                .WithMany(p => p.UserAbonement)
                .HasForeignKey(p => p.AbonementId);

            modelBuilder.Entity<UserModel>()
                .ToTable("Users")
                .HasKey(p => p.Id);

            modelBuilder.Entity<AbonementModel>()
                .ToTable("Abonements")
                .HasKey(p => p.Id);

            modelBuilder.Entity<ZoneModel>()
                .ToTable("Zone")
                .HasKey(p => p.Id);

            modelBuilder.Entity<ZoneModel>()
                .HasMany(p => p.Slopes)
                .WithOne(p => p.Zone);

            modelBuilder.Entity<SlopeModel>()
                .ToTable("Slope")
                .HasKey(p => p.Id);  
        }

        public async Task SaveAsync()
        {
            await SaveChangesAsync();
        }
    }
}
