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
                config.NewConfig<ClinicDoctor, DoctorDto.Response.Clinic>()
                        .Map(dest => dest, src => src.Clinic)
                        .Map(dest => dest.Id, src => src.ClinicId);
                //.Map(dest => dest.MedicalProfiles, src => src.MedicalProfiles);

                config.NewConfig<Doctor, DoctorDto.Response.Details>()
                        .Map(dest => dest.Clinics, src => src.ClinicsLink)
                        .Map(dest => dest.MedicalProfiles, src => src.MedicalProfiles);
            }
        }
    }
}