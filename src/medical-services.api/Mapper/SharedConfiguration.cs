using System;
using businesslogic.abstraction.ValueObjects;
using datalayer.abstraction.Entities;
using Mapster;

#pragma warning disable CS8629 // Nullable value type may be null.
namespace medical_services.api.Mapper
{
    internal class SharedConfiguration : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<MapPoint, MapPointDto?>()
                .IgnoreNullValues(true)
                .MapWith(src => new(src.NorthLatitude, src.WesternLongitude), true);

            config.NewConfig<MapPointDto?, MapPoint>()
                .Map(dest => dest.NorthLatitude, src => src.Value.NorthLatitude)
                .Map(dest => dest.WesternLongitude, src => src.Value.WesternLongitude);

            config.NewConfig<string, Uri?>()
               .MapWith(str => new Uri(str), true);
        }
    }
}
