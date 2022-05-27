using businesslogic.abstraction.Dto;
using datalayer.abstraction.Entities;
using Mapster;

namespace medical_services.api.Mapper.EtityConfigs
{
    internal static class MedicalProfileConfig
    {
        [Mapper]
        internal interface IMedicalProfileMapper
            : IMapperCodeGen<MedicalProfile, MedicalProfileDto.MedicalProfile>
        {
        }

        internal class Configuration : IRegister
        {
            public void Register(TypeAdapterConfig config)
            {
                config.NewConfig<MedicalProfile, MedicalProfileDto.MedicalProfile>()
                    .Map(dest => dest.Name.Name, src => src.Name)
                    .Map(dest => dest.Description.Description, src => src.Description);
            }
        }
    }
}
