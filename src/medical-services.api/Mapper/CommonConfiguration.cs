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
            //TypeAdapterConfig.GlobalSettings.Default.IgnoreNullValues(true);

            config.NewConfig<MapPoint, MapPointDto?>()
                .IgnoreNullValues(true)
                .MapWith(src => new(src.NorthLatitude, src.WesternLongitude), true);

            config.NewConfig<string, Uri?>()
               .MapWith(str => new Uri(str), true);
        }
    }
}
