using Microsoft.EntityFrameworkCore;
using WebApplication3.DataBase.DbModel;

namespace WebApplication3.DataBase
{
    public class DummyDbContext : DbContext
    {
        public DummyDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Country> countries { get; set; }

        public DbSet<City> cities { get; set; }

        public DbSet<State> states { get; set; }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Country>();
        modelBuilder.Entity<City>();
    }
}
