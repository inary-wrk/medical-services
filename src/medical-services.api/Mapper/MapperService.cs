using System;
using businesslogic.abstraction.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace medical_services.api.Mapper
{
    internal class MapperService : IMapper
    {
        private readonly IServiceProvider _serviceProvider;

        public MapperService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        TDestination IMapper.Map<TSource, TDestination>(TSource source)
        {
            return GetService<IMapperCodeGen<TSource, TDestination>>().Map(source);
        }

        private TService GetService<TService>()
            where TService : notnull
        {
            return _serviceProvider.GetService<TService>()
                ?? throw new InvalidOperationException($"Mapper for type {typeof(TService).FullName} is not registred.");
        }
    }
}
