using DataLayer;
using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public class ApplicationContext : DbContext
    {
        public DbSet<City> Cities { get; set; }
        public DbSet<Poi> Pois { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options):base(options)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Poi>().HasOne<City>(p => p.City).WithMany(c => c.Pois).HasForeignKey(p => p.CityId);
        }
    }
}