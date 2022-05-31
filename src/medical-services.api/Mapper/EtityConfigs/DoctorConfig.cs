using businesslogic.abstraction.Dto;
using datalayer.abstraction.Entities;
using Mapster;

namespace medical_services.api.Mapper.EtityConfigs
{
    internal static class DoctorConfig
    {
        [Mapper(IsInternal = true)]
        internal interface IDoctorMapper :
            IMapCodeGen<DoctorDto.Request.Create, Doctor>,
            IMapCodeGen<DoctorDto.Request.Update, Doctor>,
            IMapCodeGen<Doctor, DoctorDto.Response.Details>
        {
        }

        internal class Configuratiuon : IRegister
        {
            public void Register(TypeAdapterConfig config)
            {
            }
        }
    }
}