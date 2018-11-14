using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public class PoisContext : DbContext
    {
        public DbSet<Poi> Pois { get; private set; }

        public PoisContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
