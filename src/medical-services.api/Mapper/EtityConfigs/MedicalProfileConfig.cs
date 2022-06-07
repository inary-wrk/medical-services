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
            IMapCodeGen<MedicalProfile, MedicalProfileDto.Response.GetByIdDetails>,
            IMapCodeGen<IReadOnlyList<MedicalProfile>, IReadOnlyList<MedicalProfileDto.Response.Details>>
        {
        }

        internal class Configuration : IRegister
        {
            public void Register(TypeAdapterConfig config)
            {
                config.NewConfig<MedicalProfile, MedicalProfileDto.Response.GetByIdDetails>()
                    .Map(dest => dest.Clinics, src => src.ClinicDoctors);

                config.NewConfig<ClinicDoctor, MedicalProfileDto.Response.Clinic>()
                    .Map(dest => dest, src => src.Clinic)
                    .Map(dest => dest.Id, src => src.ClinicId)
                    .Map(dest => dest.Doctors, src => src.Clinic.DoctorsLink);

                config.NewConfig<ClinicDoctor, MedicalProfileDto.Response.Doctor>()
                    .Map(dest => dest, src => src.Doctor)
                    .Map(dest => dest.Id, src => src.DoctorId);

            }
        }
    }
}
