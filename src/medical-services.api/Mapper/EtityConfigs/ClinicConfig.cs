using businesslogic.abstraction.Dto;
using datalayer.abstraction.Entities;
using Mapster;

namespace medical_services.api.Mapper.EtityConfigs
{
    internal static class ClinicConfig
    {
        [Mapper]
        internal interface IClinicMapper
            : IMapperCodeGen<Clinic, ClinicDto.Clinic>
        {
        }

        internal class Configuration : IRegister
        {
            public void Register(TypeAdapterConfig config)
            {
                config.NewConfig<Clinic, ClinicDto.Clinic>()
                    .Map(dest => dest.Address, src => src.Address);

                config.NewConfig<string, ClinicDto.ValueObjects.ClinicDescription>()
                    .MapWith(src => new ClinicDto.ValueObjects.ClinicDescription(src));
            }
        }
    }
}
