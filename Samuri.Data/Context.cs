using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using Samuri.Domain;

namespace Data
{
    public class Context : DbContext
    {
        
        public DbSet<Samurai> Samuris { get; set; }
        public DbSet<Quote> Quotes { get; set; }
        public DbSet<Battle> Battles { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                          .EnableSensitiveDataLogging(true)
                          .UseSqlServer("Server = (localdb)\\MSSQLLocalDB; Database= SamuriAppDataCore;Trusted_Connection =True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SumariBattle>().HasKey(s => new { s.SamuraiId, s.BattleId });
        }
    }
}
