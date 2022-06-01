using System.Collections.Generic;
using businesslogic.abstraction.Dto;
using datalayer.abstraction.Entities;
using Mapster;

namespace medical_services.api.Mapper.EtityConfigs
{
    internal static class MedicalProfileConfig
    {
        [Mapper(IsInternal = true)]
        internal interface IMedicalProfileMapper
            : IMapCodeGen<MedicalProfileDto.Request.Create, MedicalProfile>,
            IMapCodeGen<MedicalProfileDto.Request.Update, MedicalProfile>,
            IMapCodeGen<MedicalProfile, MedicalProfileDto.Response.Details>,
            IMapCodeGen<IReadOnlyList<(MedicalProfile, int doctorsCount)>, IReadOnlyList<MedicalProfileDto.Response.Details>>
        {
        }

        internal class Configuration : IRegister
        {
            public void Register(TypeAdapterConfig config)
            {
                config.NewConfig<(MedicalProfile, int doctorsCount), MedicalProfileDto.Response.Details>()
                    .Map(dest => dest.Name, src => src.Item1.Name)
                    .Map(dest => dest.Description, src => src.Item1.Description)
                    .Map(dest => dest.DoctorsCount, src => src.doctorsCount);
            }
        }
    }
}
