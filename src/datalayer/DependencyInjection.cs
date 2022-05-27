using datalayer.abstraction.Repositories;
using datalayer.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace datalayer
{
    public static class DependencyInjection
    {
        public static IServiceCollection RegisterDatalayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContextPool<CommandDbContext>(option =>
            {
                option.UseNpgsql(configuration["CONNECTION_STRINGS:COMMANDCONNECTION"]);
            });
            services.AddDbContextPool<QueryDbContext>(option =>
            {
                option.UseNpgsql(configuration["CONNECTION_STRINGS:QUERYCONNECTION"])
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTrackingWithIdentityResolution);
            });

            services.AddScoped<IDoctorQueryRepository, DoctorQueryRepository>();
            services.AddScoped<IDoctorCommandRepository, DoctorCommandRepository>();
            return services;
        }
    }
}
