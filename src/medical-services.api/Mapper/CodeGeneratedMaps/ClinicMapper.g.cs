using System;
using businesslogic.abstraction.Dto;
using businesslogic.abstraction.ValueObjects;
using datalayer.abstraction.Entities;
using medical_services.api.Mapper.EtityConfigs;

namespace medical_services.api.Mapper.CodeGeneratedMaps
{
    internal partial class ClinicMapper : ClinicConfig.IClinicMapper
    {
        public ClinicDto.Response.Details Map(Clinic p1)
        {
            return p1 == null ? null : new ClinicDto.Response.Details(p1.Id, p1.Name, p1.Address == null ? null : new ClinicDto.ValueObject.Address(p1.Address.CountryISO, p1.Address.Region, p1.Address.Street, p1.Address.City, p1.Address.HouseNnumber, p1.Address.HouseBuilding, p1.Address.Appartament), p1.MapPoint == null ? null : new MapPointDto?(new MapPointDto(p1.MapPoint.NorthLatitude, p1.MapPoint.WesternLongitude)), p1.Description, p1.PhotoUrl == null ? null : new Uri(p1.PhotoUrl));
        }
        public Clinic Map(ClinicDto.Request.Create p2)
        {
            return p2 == null ? null : new Clinic()
            {
                Name = p2.Name,
                Address = p2.Address == null ? null : new Address()
                {
                    CountryISO = p2.Address.CountryISO,
                    Region = p2.Address.Region,
                    City = p2.Address.City,
                    Street = p2.Address.Street,
                    HouseNnumber = p2.Address.HouseNnumber,
                    HouseBuilding = p2.Address.HouseBuilding,
                    Appartament = p2.Address.Appartament
                },
                MapPoint = p2.MapPoint == null ? null : new MapPoint() {},
                Description = p2.Description,
                PhotoUrl = p2.PhotoUrl == null ? null : p2.PhotoUrl.ToString()
            };
        }
        public Clinic Map(ClinicDto.Request.Update p3)
        {
            return p3 == null ? null : new Clinic()
            {
                Name = p3.Name,
                Address = p3.Address == null ? null : new Address()
                {
                    CountryISO = p3.Address.CountryISO,
                    Region = p3.Address.Region,
                    City = p3.Address.City,
                    Street = p3.Address.Street,
                    HouseNnumber = p3.Address.HouseNnumber == null ? 0 : (int)p3.Address.HouseNnumber,
                    HouseBuilding = p3.Address.HouseBuilding,
                    Appartament = p3.Address.Appartament
                },
                MapPoint = p3.MapPoint == null ? null : new MapPoint() {},
                Description = p3.Description,
                PhotoUrl = p3.PhotoUrl == null ? null : p3.PhotoUrl.ToString()
            };
        }
    }
}