using System;
using System.Collections.Generic;
using businesslogic.abstraction.Dto;
using businesslogic.abstraction.ValueObjects;
using datalayer.abstraction.Entities;
using Mapster;
using medical_services.api.Controllers.ApiContracts;
using medical_services.api.Mapper.EtityConfigs;

namespace medical_services.api.Mapper.CodeGeneratedMaps
{
    public partial class DoctorMapper : DoctorConfig.IDoctorMapper
    {
        public DoctorDto.Doctor Map(Doctor p1)
        {
            return p1 == null ? null : new DoctorDto.Doctor((Id)p1.Id, p1 == null ? null : new DoctorDto.ValueObjects.FullName(p1.FirstName, p1.LastName, p1.Surname), new DoctorDto.ValueObjects.DoctorDescription(p1.Description), p1.PhotoUrl == null ? null : new Uri(p1.PhotoUrl), funcMain1(p1.MedicalProfile), funcMain4(p1.Clinic));
        }
        public DoctorApi.Response.Details Map(DoctorDto.Doctor p11)
        {
            return p11 == null ? null : new DoctorApi.Response.Details((long)p11.Id, p11.FullName == null ? null : p11.FullName.FirstName, p11.FullName == null ? null : p11.FullName.LastName, p11.FullName == null ? null : p11.FullName.Surname, p11.Description.Description, p11.PhotoUrl, funcMain10(p11.MedicalProfile), funcMain11(p11.Clinic));
        }
        public DoctorDto.Request.Create Map(DoctorApi.Request.CreateTest p14)
        {
            return p14 == null ? null : new DoctorDto.Request.Create(p14.FirstName, p14.LastName, p14.Surname, p14.Description, p14.PhotoUrl);
        }
        public Doctor Map(DoctorDto.Request.Create p15)
        {
            if (p15 == null)
            {
                return null;
            }
            Doctor result = new Doctor();
            
            result.FirstName = p15.FirstName;
            result.LastName = p15.LastName;
            
            if (p15.Surname != null)
            {
                result.Surname = p15.Surname;
            }
            
            if (p15.Description != null)
            {
                result.Description = p15.Description;
            }
            
            if (p15.PhotoUrl != null)
            {
                result.PhotoUrl = p15.PhotoUrl.ToString();
            }
            return result;
            
        }
        
        private List<MedicalProfileDto.MedicalProfile> funcMain1(ICollection<MedicalProfile> p2)
        {
            if (p2 == null)
            {
                return null;
            }
            List<MedicalProfileDto.MedicalProfile> result = new List<MedicalProfileDto.MedicalProfile>(p2.Count);
            
            IEnumerator<MedicalProfile> enumerator = p2.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                MedicalProfile item = enumerator.Current;
                result.Add(funcMain2(item));
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
        
        private IReadOnlyCollection<DoctorApi.Response.MedicalProfile> funcMain10(List<MedicalProfileDto.MedicalProfile> p12)
        {
            if (p12 == null)
            {
                return null;
            }
            IReadOnlyCollection<DoctorApi.Response.MedicalProfile> result = new List<DoctorApi.Response.MedicalProfile>(p12.Count);
            
            ICollection<DoctorApi.Response.MedicalProfile> list = (ICollection<DoctorApi.Response.MedicalProfile>)result;
            
            int i = 0;
            int len = p12.Count;
            
            while (i < len)
            {
                MedicalProfileDto.MedicalProfile item = p12[i];
                list.Add(item == null ? null : new DoctorApi.Response.MedicalProfile((long)item.Id, item.Name == null ? null : item.Name.ToString(), item.Description == null ? null : item.Description.ToString()));
                i++;
            }
            return result;
            
        }
        
        private IReadOnlyCollection<DoctorApi.Response.Clinic> funcMain11(List<ClinicDto.Clinic> p13)
        {
            if (p13 == null)
            {
                return null;
            }
            IReadOnlyCollection<DoctorApi.Response.Clinic> result = new List<DoctorApi.Response.Clinic>(p13.Count);
            
            ICollection<DoctorApi.Response.Clinic> list = (ICollection<DoctorApi.Response.Clinic>)result;
            
            int i = 0;
            int len = p13.Count;
            
            while (i < len)
            {
                ClinicDto.Clinic item = p13[i];
                list.Add(item == null ? null : new DoctorApi.Response.Clinic((long)item.Id, item.Name == null ? null : item.Name.ToString(), item.Description == null ? null : item.Description.ToString(), item.Address == null ? null : item.Address.ToString(), item.MapPoint == null ? null : new DoctorApi.Response.MapPoint(0d, 0d), item.PhotoUrl));
                i++;
            }
            return result;
            
        }
        
        private MedicalProfileDto.MedicalProfile funcMain2(MedicalProfile p3)
        {
            return p3 == null ? null : new MedicalProfileDto.MedicalProfile((Id)p3.Id, p3.Name == null ? null : (MedicalProfileDto.ValueObjects.MedicalProfileName)Convert.ChangeType((object)p3.Name, typeof(MedicalProfileDto.ValueObjects.MedicalProfileName)), p3.Description == null ? null : (MedicalProfileDto.ValueObjects.MedicalProfileDescription)Convert.ChangeType((object)p3.Description, typeof(MedicalProfileDto.ValueObjects.MedicalProfileDescription)), null, funcMain3(p3.Doctors));
        }
        
        private ClinicDto.Clinic funcMain5(Clinic p6)
        {
            return p6 == null ? null : new ClinicDto.Clinic((Id)p6.Id, p6.Name == null ? null : (ClinicDto.ValueObjects.ClinicName)Convert.ChangeType((object)p6.Name, typeof(ClinicDto.ValueObjects.ClinicName)), p6.Address == null ? null : new ClinicDto.ValueObjects.Address(null, p6.Address.Region, p6.Address.City, p6.Address.Street, p6.Address.HouseNnumber, (int?)p6.Address.HouseBuilding, (int?)p6.Address.Appartament), new ClinicDto.ValueObjects.ClinicDescription(p6.Description), funcMain6(p6.Doctor), funcMain7(p6.MedicalProfile), new MapPointDto?(new MapPointDto(p6.MapPoint.NorthLatitude, p6.MapPoint.WesternLongitude)), p6.PhotoUrl == null ? null : new Uri(p6.PhotoUrl));
        }
        
        private List<DoctorDto.Doctor> funcMain3(ICollection<Doctor> p4)
        {
            if (p4 == null)
            {
                return null;
            }
            List<DoctorDto.Doctor> result = new List<DoctorDto.Doctor>(p4.Count);
            
            IEnumerator<Doctor> enumerator = p4.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                Doctor item = enumerator.Current;
                result.Add(TypeAdapter<Doctor, DoctorDto.Doctor>.Map.Invoke(item));
            }
            return result;
            
        }
        
        private List<DoctorDto.Doctor> funcMain6(ICollection<Doctor> p7)
        {
            if (p7 == null)
            {
                return null;
            }
            List<DoctorDto.Doctor> result = new List<DoctorDto.Doctor>(p7.Count);
            
            IEnumerator<Doctor> enumerator = p7.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                Doctor item = enumerator.Current;
                result.Add(TypeAdapter<Doctor, DoctorDto.Doctor>.Map.Invoke(item));
            }
            return result;
            
        }
        
        private List<MedicalProfileDto.MedicalProfile> funcMain7(ICollection<MedicalProfile> p8)
        {
            if (p8 == null)
            {
                return null;
            }
            List<MedicalProfileDto.MedicalProfile> result = new List<MedicalProfileDto.MedicalProfile>(p8.Count);
            
            IEnumerator<MedicalProfile> enumerator = p8.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                MedicalProfile item = enumerator.Current;
                result.Add(funcMain8(item));
            }
            return result;
            
        }
        
        private MedicalProfileDto.MedicalProfile funcMain8(MedicalProfile p9)
        {
            return p9 == null ? null : new MedicalProfileDto.MedicalProfile((Id)p9.Id, p9.Name == null ? null : (MedicalProfileDto.ValueObjects.MedicalProfileName)Convert.ChangeType((object)p9.Name, typeof(MedicalProfileDto.ValueObjects.MedicalProfileName)), p9.Description == null ? null : (MedicalProfileDto.ValueObjects.MedicalProfileDescription)Convert.ChangeType((object)p9.Description, typeof(MedicalProfileDto.ValueObjects.MedicalProfileDescription)), null, funcMain9(p9.Doctors));
        }
        
        private List<DoctorDto.Doctor> funcMain9(ICollection<Doctor> p10)
        {
            if (p10 == null)
            {
                return null;
            }
            List<DoctorDto.Doctor> result = new List<DoctorDto.Doctor>(p10.Count);
            
            IEnumerator<Doctor> enumerator = p10.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                Doctor item = enumerator.Current;
                result.Add(TypeAdapter<Doctor, DoctorDto.Doctor>.Map.Invoke(item));
            }
            return result;
            
        }
    }
}