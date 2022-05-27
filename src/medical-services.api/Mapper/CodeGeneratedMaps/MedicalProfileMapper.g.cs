using System;
using System.Collections.Generic;
using businesslogic.abstraction.Dto;
using businesslogic.abstraction.ValueObjects;
using datalayer.abstraction.Entities;
using Mapster;
using medical_services.api.Mapper.EtityConfigs;

namespace medical_services.api.Mapper.CodeGeneratedMaps
{
    public partial class MedicalProfileMapper : MedicalProfileConfig.IMedicalProfileMapper
    {
        public MedicalProfileDto.MedicalProfile Map(MedicalProfile p1)
        {
            return p1 == null ? null : new MedicalProfileDto.MedicalProfile((Id)p1.Id, p1.Name == null ? null : (MedicalProfileDto.ValueObjects.MedicalProfileName)Convert.ChangeType((object)p1.Name, typeof(MedicalProfileDto.ValueObjects.MedicalProfileName)), p1.Description == null ? null : (MedicalProfileDto.ValueObjects.MedicalProfileDescription)Convert.ChangeType((object)p1.Description, typeof(MedicalProfileDto.ValueObjects.MedicalProfileDescription)), null, funcMain1(p1.Doctors));
        }
        
        private List<DoctorDto.Doctor> funcMain1(ICollection<Doctor> p2)
        {
            if (p2 == null)
            {
                return null;
            }
            List<DoctorDto.Doctor> result = new List<DoctorDto.Doctor>(p2.Count);
            
            IEnumerator<Doctor> enumerator = p2.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                Doctor item = enumerator.Current;
                result.Add(funcMain2(item));
            }
            return result;
            
        }
        
        private DoctorDto.Doctor funcMain2(Doctor p3)
        {
            return p3 == null ? null : new DoctorDto.Doctor((Id)p3.Id, p3 == null ? null : new DoctorDto.ValueObjects.FullName(p3.FirstName, p3.LastName, p3.Surname), new DoctorDto.ValueObjects.DoctorDescription(p3.Description), p3.PhotoUrl == null ? null : new Uri(p3.PhotoUrl), funcMain3(p3.MedicalProfile), funcMain4(p3.Clinic));
        }
        
        private List<MedicalProfileDto.MedicalProfile> funcMain3(ICollection<MedicalProfile> p4)
        {
            if (p4 == null)
            {
                return null;
            }
            List<MedicalProfileDto.MedicalProfile> result = new List<MedicalProfileDto.MedicalProfile>(p4.Count);
            
            IEnumerator<MedicalProfile> enumerator = p4.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                MedicalProfile item = enumerator.Current;
                result.Add(TypeAdapter<MedicalProfile, MedicalProfileDto.MedicalProfile>.Map.Invoke(item));
            }
            return result;
            
        }
        
        private List<ClinicDto.Clinic> funcMain4(ICollection<Clinic> p5)
        {
            if (p5 == null)
            {
                return null;
            }
            List<ClinicDto.Clinic> result = new List<ClinicDto.Clinic>(p5.Count);
            
            IEnumerator<Clinic> enumerator = p5.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                Clinic item = enumerator.Current;
                result.Add(funcMain5(item));
            }
            return result;
            
        }
        
        private ClinicDto.Clinic funcMain5(Clinic p6)
        {
            return p6 == null ? null : new ClinicDto.Clinic((Id)p6.Id, p6.Name == null ? null : (ClinicDto.ValueObjects.ClinicName)Convert.ChangeType((object)p6.Name, typeof(ClinicDto.ValueObjects.ClinicName)), p6.Address == null ? null : new ClinicDto.ValueObjects.Address(null, p6.Address.Region, p6.Address.City, p6.Address.Street, p6.Address.HouseNnumber, (int?)p6.Address.HouseBuilding, (int?)p6.Address.Appartament), new ClinicDto.ValueObjects.ClinicDescription(p6.Description), TypeAdapter<ICollection<Doctor>, List<DoctorDto.Doctor>>.Map.Invoke(p6.Doctor), funcMain6(p6.MedicalProfile), new MapPointDto?(new MapPointDto(p6.MapPoint.NorthLatitude, p6.MapPoint.WesternLongitude)), p6.PhotoUrl == null ? null : new Uri(p6.PhotoUrl));
        }
        
        private List<MedicalProfileDto.MedicalProfile> funcMain6(ICollection<MedicalProfile> p7)
        {
            if (p7 == null)
            {
                return null;
            }
            List<MedicalProfileDto.MedicalProfile> result = new List<MedicalProfileDto.MedicalProfile>(p7.Count);
            
            IEnumerator<MedicalProfile> enumerator = p7.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                MedicalProfile item = enumerator.Current;
                result.Add(TypeAdapter<MedicalProfile, MedicalProfileDto.MedicalProfile>.Map.Invoke(item));
            }
            return result;
            
        }
    }
}