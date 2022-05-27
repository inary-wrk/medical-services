using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace businesslogic
{
    public static class DependencyInjection
    {
       public static IServiceCollection RegisterBusinesslogic(this IServiceCollection services)
        {
            services.Scan(scan => scan
                .FromCallingAssembly()
                .AddClasses(classes=> classes.AssignableTo(typeof(IRequestHandler<,>)))
                .AsImplementedInterfaces()
                .WithScopedLifetime());
            return services;
        }
    }
}
