using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace GoldenCraft.Models
{
    public class DataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            var configuration = builder.Build();
            optionsBuilder.UseMySql(configuration["ConnectionStrings:DefaultConnection"]);
        }

        public DbSet<Player> Players { get; set; }
        public DbSet<Kill> Kills { get; set; }
        public DbSet<Move> Moves { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Player>().HasKey(it => it.Uuid);
            modelBuilder.Entity<Kill>().HasKey(it => new { it.PlayerUuid, it.World, it.VictimType, it.VictimName, it.Weapon });
            modelBuilder.Entity<Move>().HasKey(it => new { it.PlayerUuid, it.World, it.Type });
        } 
    }
}
