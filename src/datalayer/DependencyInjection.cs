using System;
using datalayer.abstraction.Repositories;
using datalayer.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace datalayer
{
    public static class DependencyInjection
    {
        public static IServiceCollection RegisterDatalayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContextPool<CommandDbContext>(options =>
            {
                options.UseNpgsql(configuration["CONNECTION_STRINGS:COMMANDCONNECTION"])
                .EnableSensitiveDataLogging(true);
            });
            services.AddDbContextPool<QueryDbContext>(options =>
            {
                options.UseNpgsql(configuration["CONNECTION_STRINGS:QUERYCONNECTION"])
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTrackingWithIdentityResolution)
                .EnableSensitiveDataLogging(true);
            });

            services.AddScoped<IDoctorQueryRepository, DoctorQueryRepository>();
            services.AddScoped<IDoctorCommandRepository, DoctorCommandRepository>();
            services.AddScoped<IMedicalProfileQueryRepository, MedicalProfileQueryRepository>();
            services.AddScoped<IMedicalProfileCommandRepository, MedicalProfileCommandRepository>();
            services.AddScoped<IClinicQueryRepository, ClinicQueryRepository>();
            services.AddScoped<IClinicCommandRepository, ClinicCommandRepository>();
            return services;
        }
    }
}
