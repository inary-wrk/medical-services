using System;
using datalayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace migrations
{
    public static class Program
    {
        static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        private static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddDbContextFactory<ApplicationDbContext>(options =>
                    {
                        options.UseNpgsql(
                            hostContext.Configuration["CONNECTION_STRING"],
                            l => l.MigrationsAssembly(nameof(migrations)))
                        .UseLoggerFactory(LoggerFactory.Create(builder =>
                        {
                            builder.AddConsole()
                            .AddFilter((category, level) =>
                            category == DbLoggerCategory.Database.Command.Name
                            && level == LogLevel.Information);
                        }));
                    });
                    services.AddHostedService<Worker>();
                });
    }
}
