using System.Net;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace datalayer
{
    public sealed class QueryDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public QueryDbContext(DbContextOptions<QueryDbContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_configuration["CONNECTION_STRINGS:QUERYCONNECTION"])
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTrackingWithIdentityResolution);
            base.OnConfiguring(optionsBuilder);
        }
    }
}
