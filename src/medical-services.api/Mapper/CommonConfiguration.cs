using System;
using businesslogic.abstraction.ValueObjects;
using datalayer.abstraction.Entities;
using Mapster;

namespace medical_services.api.Mapper
{
    internal class CommonConfiguration : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            TypeAdapterConfig.GlobalSettings.Default.IgnoreNullValues(true);

            config.NewConfig<long, Id>()
                .MapWith(src => (Id)src);

            config.NewConfig<Id, long>()
                .MapWith(src => (long)src);

            config.NewConfig<MapPoint, MapPointDto?>()
                .IgnoreNullValues(true)
                .MapWith(src => new(src.NorthLatitude, src.WesternLongitude));

            config.NewConfig<string, Uri?>()
                .IgnoreNullValues(true)
                .MapWith(src => new(src), true);
        }
    }
}
