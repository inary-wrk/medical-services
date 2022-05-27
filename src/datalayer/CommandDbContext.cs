using Microsoft.EntityFrameworkCore;

namespace datalayer
{
    public sealed class CommandDbContext : BaseDbContext
    {
        public CommandDbContext(DbContextOptions<CommandDbContext> options)
            : base(options)
        {
        }
    }
}
