using businesslogic.abstraction.Dto;
using datalayer.abstraction.Entities;
using Mapster;
using medical_services.api.Controllers.ApiContracts;

namespace medical_services.api.Mapper.EtityConfigs
{
    internal static class DoctorConfig
    {
        [Mapper]
        internal interface IDoctorMapper :
            IMapperCodeGen<Doctor, DoctorDto.Doctor>,
            IMapperCodeGen<DoctorDto.Doctor, DoctorApi.Response.Details>,
            IMapperCodeGen<DoctorApi.Request.CreateTest, DoctorDto.Request.Create>,
            IMapperCodeGen<DoctorDto.Request.Create, Doctor>
        {
        }

        internal class Configuratiuon : IRegister
        {
            public void Register(TypeAdapterConfig config)
            {
                config.NewConfig<Doctor, DoctorDto.Doctor>()
                    .Map(dest => dest.FullName, src => src);

                config.NewConfig<string, DoctorDto.ValueObjects.DoctorDescription>()
                    .MapWith(src => new(src));
                config.NewConfig<DoctorDto.ValueObjects.DoctorDescription, string>()
                    .MapWith(src => src.Description);

                config.NewConfig<DoctorDto.Doctor, DoctorApi.Response.Details>()
                    .Map(dest => dest.FirstName, src => src.FullName.FirstName)
                    .Map(dest => dest.LastName, src => src.FullName.LastName)
                    .Map(dest => dest.Surname, src => src.FullName.Surname);

                config.NewConfig<DoctorApi.Request.CreateTest, DoctorDto.Request.Create>();
            }
        }
    }
}