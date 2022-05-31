using businesslogic.abstraction.Dto;
using datalayer.abstraction.Entities;
using Mapster;

namespace medical_services.api.Mapper.EtityConfigs
{
    internal static class MedicalProfileConfig
    {
        [Mapper(IsInternal = true)]
        internal interface IMedicalProfileMapper
            :IMapCodeGen<MedicalProfileDto.Request.Create, MedicalProfile>,
            IMapCodeGen<MedicalProfileDto.Request.Update, MedicalProfile>,
            IMapCodeGen<MedicalProfile, MedicalProfileDto.Response.Details>
        {
        }

        internal class Configuration : IRegister
        {
            public void Register(TypeAdapterConfig config)
            {
            }
        }
    }
}
