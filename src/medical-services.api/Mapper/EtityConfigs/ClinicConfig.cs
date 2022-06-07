using businesslogic.abstraction.Dto;
using businesslogic.abstraction.ValueObjects;
using datalayer.abstraction.Entities;
using Mapster;
using SlugGenerator;

namespace medical_services.api.Mapper.EtityConfigs
{
    internal static class ClinicConfig
    {
        [Mapper(IsInternal = true)]
        internal interface IClinicMapper
            : IMapCodeGen<Clinic, ClinicDto.Response.Details>,
            IMapCodeGen<ClinicDto.Request.Create, Clinic>,
            IMapToExistCodeGen<ClinicDto.Request.Update, Clinic>
        {
        }

        internal class Configuration : IRegister
        {
            public void Register(TypeAdapterConfig config)
            {
                config.NewConfig<ClinicDto.Request.Update, Clinic>()
                    .IgnoreNullValues(true);

                config.NewConfig<ClinicDto.Request.UpdateAddress?, Address>()
                    .IgnoreNullValues(true);

                config.NewConfig<ClinicDto.Request.CreateAddress, Address>()
                    .Map(dest => dest.CityCode, src => src.City.GenerateSlug("-"));

                config.NewConfig<Address, ClinicDto.Response.Address>()
                    .MapToConstructor(true)
                    .ConstructUsing(adr => new(adr.CountryISO,
                                                                        adr.City,
                                                                        adr.Region,
                                                                        adr.CityCode,
                                                                        adr.Street,
                                                                        adr.HouseNnumber,
                                                                        adr.HouseBuilding,
                                                                        adr.Appartament));

                config.NewConfig<ClinicDoctor, ClinicDto.Response.Doctor>()
                        .Map(dest => dest, src => src.Doctor)
                        .Map(dest => dest.Id, src => src.DoctorId)
                        .Map(dest => dest.MedicalProfiles, src => src.MedicalProfiles);
                config.NewConfig<Clinic, ClinicDto.Response.Details>()
                        .Map(dest => dest.Doctors, src => src.DoctorsLink);
            }
        }
    }
}
