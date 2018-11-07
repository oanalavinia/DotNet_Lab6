using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public class CitiesContext : DbContext
    {
        public DbSet<City> Cities { get; private set; }

        public CitiesContext(DbContextOptions options): base(options)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }
    }
}
