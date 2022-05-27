using System.Threading;
using System.Threading.Tasks;
using datalayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace migrations
{
    internal class Worker : IHostedService
    {
        private readonly IDbContextFactory<MigrationDbContext> _contextFactory;

        public Worker(IDbContextFactory<MigrationDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            using var context = _contextFactory.CreateDbContext();
            await context.Database.MigrateAsync(cancellationToken);
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}