using System.Collections.Generic;
using businesslogic.abstraction.Dto;
using businesslogic.abstraction.ValueObjects;
using datalayer.abstraction.Entities;
using medical_services.api.Mapper.EtityConfigs;

namespace medical_services.api.Mapper.CodeGeneratedMaps
{
    internal partial class MedicalProfileMapper : MedicalProfileConfig.IMedicalProfileMapper
    {
        public MedicalProfile Map(MedicalProfileDto.Request.Create p1)
        {
            return p1 == null ? null : new MedicalProfile()
            {
                Name = p1.Name,
                Description = p1.Description
            };
        }
        public MedicalProfile Map(MedicalProfileDto.Request.Update p2)
        {
            return p2 == null ? null : new MedicalProfile()
            {
                Name = p2.Name,
                Description = p2.Description
            };
        }
        public MedicalProfileDto.Response.GetByIdDetails Map(MedicalProfile p3)
        {
            return p3 == null ? null : new MedicalProfileDto.Response.GetByIdDetails(p3.Id, p3.Name, p3.Description, funcMain1(p3.ClinicDoctors));
        }
        public IReadOnlyList<MedicalProfileDto.Response.Details> Map(IReadOnlyList<MedicalProfile> p9)
        {
            if (p9 == null)
            {
                return null;
            }
            IReadOnlyList<MedicalProfileDto.Response.Details> result = new List<MedicalProfileDto.Response.Details>();
            
            ICollection<MedicalProfileDto.Response.Details> list = (ICollection<MedicalProfileDto.Response.Details>)result;
            
            IEnumerator<MedicalProfile> enumerator = p9.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                MedicalProfile item = enumerator.Current;
                list.Add(item == null ? null : new MedicalProfileDto.Response.Details(item.Id, item.Name, item.Description, item.Doctors == null ? null : (int?)item.Doctors.Count));
            }
            return result;
            
        }
        
        private IReadOnlyList<MedicalProfileDto.Response.Clinic> funcMain1(ICollection<ClinicDoctor> p4)
        {
            if (p4 == null)
            {
                return null;
            }
            IReadOnlyList<MedicalProfileDto.Response.Clinic> result = new List<MedicalProfileDto.Response.Clinic>(p4.Count);
            
            ICollection<MedicalProfileDto.Response.Clinic> list = (ICollection<MedicalProfileDto.Response.Clinic>)result;
            
            IEnumerator<ClinicDoctor> enumerator = p4.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                ClinicDoctor item = enumerator.Current;
                list.Add(funcMain2(item));
            }
            return result;
            
        }
        
        private MedicalProfileDto.Response.Clinic funcMain2(ClinicDoctor p5)
        {
            return p5 == null ? null : new MedicalProfileDto.Response.Clinic(p5.ClinicId, p5.Clinic == null ? null : p5.Clinic.Name, p5.Clinic == null ? null : p5.Clinic.Description, funcMain3(p5.Clinic == null ? null : p5.Clinic.Address), funcMain4(p5.Clinic == null ? null : p5.Clinic.MapPoint), p5.Clinic == null ? null : p5.Clinic.PhotoUrl, funcMain5(p5.Clinic == null ? null : p5.Clinic.DoctorsLink));
        }
        
        private MedicalProfileDto.Response.Address funcMain3(Address p6)
        {
            return p6 == null ? null : new MedicalProfileDto.Response.Address(null, p6.Region, p6.City, p6.CityCode, p6.Street, p6.HouseNnumber, p6.HouseBuilding, p6.Appartament);
        }
        
        private MapPointDto? funcMain4(MapPoint p7)
        {
            return p7 == null ? null : new MapPointDto?(new MapPointDto(p7.NorthLatitude, p7.WesternLongitude));
        }
        
        private IReadOnlyList<MedicalProfileDto.Response.Doctor> funcMain5(ICollection<ClinicDoctor> p8)
        {
            if (p8 == null)
            {
                return null;
            }
            IReadOnlyList<MedicalProfileDto.Response.Doctor> result = new List<MedicalProfileDto.Response.Doctor>(p8.Count);
            
            ICollection<MedicalProfileDto.Response.Doctor> list = (ICollection<MedicalProfileDto.Response.Doctor>)result;
            
            IEnumerator<ClinicDoctor> enumerator = p8.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                ClinicDoctor item = enumerator.Current;
                list.Add(item == null ? null : new MedicalProfileDto.Response.Doctor(item.DoctorId, item.Doctor == null ? null : item.Doctor.FirstName, item.Doctor == null ? null : item.Doctor.LastName, item.Doctor == null ? null : item.Doctor.Surname, item.Doctor == null ? null : item.Doctor.Description, item.Doctor == null ? null : item.Doctor.PhotoUrl));
            }
            return result;
            
        }
    }
}