using Microsoft.EntityFrameworkCore;

namespace datalayer
{
    public sealed class MigrationDbContext : BaseDbContext
    {
        public MigrationDbContext(DbContextOptions<MigrationDbContext> contextOptions)
            : base(contextOptions)
        {
        }
    }
}
