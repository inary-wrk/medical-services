using System;
using System.Collections.Generic;
using businesslogic.abstraction.Dto;
using businesslogic.abstraction.ValueObjects;
using datalayer.abstraction.Entities;
using Mapster;
using medical_services.api.Mapper.EtityConfigs;

namespace medical_services.api.Mapper.CodeGeneratedMaps
{
    public partial class ClinicMapper : ClinicConfig.IClinicMapper
    {
        public ClinicDto.Clinic Map(Clinic p1)
        {
            return p1 == null ? null : new ClinicDto.Clinic((Id)p1.Id, p1.Name == null ? null : (ClinicDto.ValueObjects.ClinicName)Convert.ChangeType((object)p1.Name, typeof(ClinicDto.ValueObjects.ClinicName)), p1.Address == null ? null : new ClinicDto.ValueObjects.Address(null, p1.Address.Region, p1.Address.City, p1.Address.Street, p1.Address.HouseNnumber, (int?)p1.Address.HouseBuilding, (int?)p1.Address.Appartament), new ClinicDto.ValueObjects.ClinicDescription(p1.Description), funcMain1(p1.Doctor), funcMain5(p1.MedicalProfile), new MapPointDto?(new MapPointDto(p1.MapPoint.NorthLatitude, p1.MapPoint.WesternLongitude)), p1.PhotoUrl == null ? null : new Uri(p1.PhotoUrl));
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
        
        private List<MedicalProfileDto.MedicalProfile> funcMain5(ICollection<MedicalProfile> p6)
        {
            if (p6 == null)
            {
                return null;
            }
            List<MedicalProfileDto.MedicalProfile> result = new List<MedicalProfileDto.MedicalProfile>(p6.Count);
            
            IEnumerator<MedicalProfile> enumerator = p6.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                MedicalProfile item = enumerator.Current;
                result.Add(funcMain6(item));
            }
            return result;
            
        }
        
        private DoctorDto.Doctor funcMain2(Doctor p3)
        {
            return p3 == null ? null : new DoctorDto.Doctor((Id)p3.Id, p3 == null ? null : new DoctorDto.ValueObjects.FullName(p3.FirstName, p3.LastName, p3.Surname), new DoctorDto.ValueObjects.DoctorDescription(p3.Description), p3.PhotoUrl == null ? null : new Uri(p3.PhotoUrl), funcMain3(p3.MedicalProfile), funcMain4(p3.Clinic));
        }
        
        private MedicalProfileDto.MedicalProfile funcMain6(MedicalProfile p7)
        {
            return p7 == null ? null : new MedicalProfileDto.MedicalProfile((Id)p7.Id, p7.Name == null ? null : (MedicalProfileDto.ValueObjects.MedicalProfileName)Convert.ChangeType((object)p7.Name, typeof(MedicalProfileDto.ValueObjects.MedicalProfileName)), p7.Description == null ? null : (MedicalProfileDto.ValueObjects.MedicalProfileDescription)Convert.ChangeType((object)p7.Description, typeof(MedicalProfileDto.ValueObjects.MedicalProfileDescription)), null, funcMain7(p7.Doctors));
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
                result.Add(item == null ? null : new MedicalProfileDto.MedicalProfile((Id)item.Id, item.Name == null ? null : (MedicalProfileDto.ValueObjects.MedicalProfileName)Convert.ChangeType((object)item.Name, typeof(MedicalProfileDto.ValueObjects.MedicalProfileName)), item.Description == null ? null : (MedicalProfileDto.ValueObjects.MedicalProfileDescription)Convert.ChangeType((object)item.Description, typeof(MedicalProfileDto.ValueObjects.MedicalProfileDescription)), null, TypeAdapter<ICollection<Doctor>, List<DoctorDto.Doctor>>.Map.Invoke(item.Doctors)));
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
                result.Add(TypeAdapter<Clinic, ClinicDto.Clinic>.Map.Invoke(item));
            }
            return result;
            
        }
        
        private List<DoctorDto.Doctor> funcMain7(ICollection<Doctor> p8)
        {
            if (p8 == null)
            {
                return null;
            }
            List<DoctorDto.Doctor> result = new List<DoctorDto.Doctor>(p8.Count);
            
            IEnumerator<Doctor> enumerator = p8.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                Doctor item = enumerator.Current;
                result.Add(funcMain8(item));
            }
            return result;
            
        }
        
        private DoctorDto.Doctor funcMain8(Doctor p9)
        {
            return p9 == null ? null : new DoctorDto.Doctor((Id)p9.Id, p9 == null ? null : new DoctorDto.ValueObjects.FullName(p9.FirstName, p9.LastName, p9.Surname), new DoctorDto.ValueObjects.DoctorDescription(p9.Description), p9.PhotoUrl == null ? null : new Uri(p9.PhotoUrl), TypeAdapter<ICollection<MedicalProfile>, List<MedicalProfileDto.MedicalProfile>>.Map.Invoke(p9.MedicalProfile), funcMain9(p9.Clinic));
        }
        
        private List<ClinicDto.Clinic> funcMain9(ICollection<Clinic> p10)
        {
            if (p10 == null)
            {
                return null;
            }
            List<ClinicDto.Clinic> result = new List<ClinicDto.Clinic>(p10.Count);
            
            IEnumerator<Clinic> enumerator = p10.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                Clinic item = enumerator.Current;
                result.Add(TypeAdapter<Clinic, ClinicDto.Clinic>.Map.Invoke(item));
            }
            return result;
            
        }
    }
}