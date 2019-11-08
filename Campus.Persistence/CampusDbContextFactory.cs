using Microsoft.EntityFrameworkCore;
using Campus.Persistence.Infrastructure;

namespace Campus.Persistence
{
    public class CampusDbContextFactory : DesignTimeDbContextFactoryBase<CampusDbContext>
    {
        protected override CampusDbContext CreateNewInstance(DbContextOptions<CampusDbContext> options)
        {
            return new CampusDbContext(options);
        }
    }
}
