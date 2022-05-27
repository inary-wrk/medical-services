using Microsoft.EntityFrameworkCore;

namespace datalayer
{
    public sealed class QueryDbContext : BaseDbContext
    {
        public QueryDbContext(DbContextOptions<QueryDbContext> options)
            : base(options)
        {
        }
    }
}
