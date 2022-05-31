using businesslogic.abstraction.Dto;
using datalayer.abstraction.Entities;
using Mapster;

namespace medical_services.api.Mapper.EtityConfigs
{
    internal static class ClinicConfig
    {
        [Mapper(IsInternal = true)]
        internal interface IClinicMapper
            : IMapCodeGen<Clinic, ClinicDto.Response.Details>,
            IMapCodeGen<ClinicDto.Request.Create, Clinic>,
            IMapCodeGen<ClinicDto.Request.Update, Clinic>
        {
        }

        internal class Configuration : IRegister
        {
            public void Register(TypeAdapterConfig config)
            {
                config.NewConfig<Address, ClinicDto.ValueObject.Address>()
                    .MapToConstructor(true)
                    .ConstructUsing(src => new (src.CountryISO,
                                                                         src.Region,
                                                                         src.Street,
                                                                         src.City,
                                                                         src.HouseNnumber,
                                                                         src.HouseBuilding,
                                                                         src.Appartament));

            }
        }
    }
}
