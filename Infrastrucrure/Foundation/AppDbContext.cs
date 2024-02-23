using Infrastrucrure.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Infrastrucrure.Foundation
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions)
            : base(dbContextOptions)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new LicenseConfiguration());
        }
    }
}
