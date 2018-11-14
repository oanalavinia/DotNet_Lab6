using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    class PoisContext : DbContext
    {
        public DbSet<Poi> Pois { get; private set; }

        public PoisContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
