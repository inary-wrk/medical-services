using businesslogic.abstraction.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace medical_services.api.Mapper
{
    internal static class DependencyInjection
    {
        internal static IServiceCollection RegisterMapper(this IServiceCollection services)
        {
            services.AddScoped<IMapper, MapperService>();

            services.Scan(scan => scan
                .FromAssembliesOf(typeof(IMapperCodeGen<,>))
                .AddClasses(classes => classes.AssignableTo(typeof(IMapperCodeGen<,>)))
                .AsImplementedInterfaces()
                .WithScopedLifetime());
            return services;
        }
    }
}
