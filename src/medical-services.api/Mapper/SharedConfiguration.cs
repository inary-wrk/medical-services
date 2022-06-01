using System;
using businesslogic.abstraction.ValueObjects;
using datalayer.abstraction.Entities;
using Mapster;

namespace medical_services.api.Mapper
{
    internal class SharedConfiguration : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<MapPoint, MapPointDto?>()
                .IgnoreNullValues(true)
                .MapWith(src => new(src.NorthLatitude, src.WesternLongitude), true);

            config.NewConfig<string, Uri?>()
               .MapWith(str => new Uri(str), true);
        }
    }
}
