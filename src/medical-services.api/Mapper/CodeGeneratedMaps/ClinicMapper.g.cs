using System.Collections.Generic;
using businesslogic.abstraction.Dto;
using businesslogic.abstraction.ValueObjects;
using datalayer.abstraction.Entities;
using medical_services.api.Mapper.EtityConfigs;
using SlugGenerator;

namespace medical_services.api.Mapper.CodeGeneratedMaps
{
    internal partial class ClinicMapper : ClinicConfig.IClinicMapper
    {
        public ClinicDto.Response.Details Map(Clinic p1)
        {
            return p1 == null ? null : new ClinicDto.Response.Details(p1.Id, p1.Name, p1.Description, p1.Address == null ? null : new ClinicDto.Response.Address(p1.Address.CountryISO, p1.Address.City, p1.Address.Region, p1.Address.CityCode, p1.Address.Street, p1.Address.HouseNnumber, p1.Address.HouseBuilding, p1.Address.Appartament), p1.MapPoint == null ? null : new MapPointDto?(new MapPointDto(p1.MapPoint.NorthLatitude, p1.MapPoint.WesternLongitude)), p1.PhotoUrl, funcMain1(p1.DoctorsLink));
        }
        public Clinic Map(ClinicDto.Request.Create p5)
        {
            return p5 == null ? null : new Clinic()
            {
                Name = p5.Name,
                Address = p5.Address == null ? null : new Address()
                {
                    CountryISO = p5.Address.CountryISO,
                    Region = p5.Address.Region,
                    City = p5.Address.City,
                    CityCode = p5.Address.City.GenerateSlug("-"),
                    Street = p5.Address.Street,
                    HouseNnumber = p5.Address.HouseNnumber,
                    HouseBuilding = p5.Address.HouseBuilding,
                    Appartament = p5.Address.Appartament
                },
                MapPoint = p5.MapPoint == null ? null : new MapPoint()
                {
                    NorthLatitude = p5.MapPoint.Value.NorthLatitude,
                    WesternLongitude = p5.MapPoint.Value.WesternLongitude
                },
                Description = p5.Description,
                PhotoUrl = p5.PhotoUrl == null ? null : p5.PhotoUrl.ToString()
            };
        }
        public Clinic Map(ClinicDto.Request.Update p6, Clinic p7)
        {
            if (p6 == null)
            {
                return null;
            }
            Clinic result = p7 ?? new Clinic();
            
            if (p6.Name != null)
            {
                result.Name = p6.Name;
            }
            
            if (p6.Address != null)
            {
                result.Address = funcMain4(p6.Address, result.Address);
            }
            
            if (p6.MapPoint != null)
            {
                result.MapPoint = funcMain5(p6.MapPoint, result.MapPoint);
            }
            
            if (p6.Description != null)
            {
                result.Description = p6.Description;
            }
            
            if (p6.PhotoUrl != null)
            {
                result.PhotoUrl = p6.PhotoUrl.ToString();
            }
            return result;
            
        }
        
        private IReadOnlyList<ClinicDto.Response.Doctor> funcMain1(ICollection<ClinicDoctor> p2)
        {
            if (p2 == null)
            {
                return null;
            }
            IReadOnlyList<ClinicDto.Response.Doctor> result = new List<ClinicDto.Response.Doctor>(p2.Count);
            
            ICollection<ClinicDto.Response.Doctor> list = (ICollection<ClinicDto.Response.Doctor>)result;
            
            IEnumerator<ClinicDoctor> enumerator = p2.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                ClinicDoctor item = enumerator.Current;
                list.Add(funcMain2(item));
            }
            return result;
            
        }
        
        private Address funcMain4(ClinicDto.Request.UpdateAddress p8, Address p9)
        {
            if (p8 == null)
            {
                return null;
            }
            Address result = p9 ?? new Address();
            
            if (p8.CountryISO != null)
            {
                result.CountryISO = p8.CountryISO;
            }
            
            if (p8.Region != null)
            {
                result.Region = p8.Region;
            }
            
            if (p8.City != null)
            {
                result.City = p8.City;
            }
            
            if (p8.Street != null)
            {
                result.Street = p8.Street;
            }
            
            if (p8.HouseNnumber != null)
            {
                result.HouseNnumber = (int)p8.HouseNnumber;
            }
            
            if (p8.HouseBuilding != null)
            {
                result.HouseBuilding = p8.HouseBuilding;
            }
            
            if (p8.Appartament != null)
            {
                result.Appartament = p8.Appartament;
            }
            return result;
            
        }
        
        private MapPoint funcMain5(MapPointDto? p10, MapPoint p11)
        {
            if (p10 == null)
            {
                return null;
            }
            MapPoint result = p11 ?? new MapPoint();
            
            result.NorthLatitude = p10.Value.NorthLatitude;
            result.WesternLongitude = p10.Value.WesternLongitude;
            return result;
            
        }
        
        private ClinicDto.Response.Doctor funcMain2(ClinicDoctor p3)
        {
            return p3 == null ? null : new ClinicDto.Response.Doctor(p3.DoctorId, p3.Doctor == null ? null : p3.Doctor.FirstName, p3.Doctor == null ? null : p3.Doctor.LastName, p3.Doctor == null ? null : p3.Doctor.Surname, p3.Doctor == null ? null : p3.Doctor.Description, p3.Doctor == null ? null : p3.Doctor.PhotoUrl, funcMain3(p3.MedicalProfiles));
        }
        
        private IReadOnlyList<ClinicDto.Response.MedicalProfile> funcMain3(ICollection<MedicalProfile> p4)
        {
            if (p4 == null)
            {
                return null;
            }
            IReadOnlyList<ClinicDto.Response.MedicalProfile> result = new List<ClinicDto.Response.MedicalProfile>(p4.Count);
            
            ICollection<ClinicDto.Response.MedicalProfile> list = (ICollection<ClinicDto.Response.MedicalProfile>)result;
            
            IEnumerator<MedicalProfile> enumerator = p4.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                MedicalProfile item = enumerator.Current;
                list.Add(item == null ? null : new ClinicDto.Response.MedicalProfile(item.Id, item.Name, item.Description));
            }
            return result;
            
        }
    }
}