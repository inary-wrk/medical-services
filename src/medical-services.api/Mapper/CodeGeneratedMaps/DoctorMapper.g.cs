using System;
using System.Collections.Generic;
using businesslogic.abstraction.Dto;
using datalayer.abstraction.Entities;
using medical_services.api.Mapper.EtityConfigs;

namespace medical_services.api.Mapper.CodeGeneratedMaps
{
    internal partial class DoctorMapper : DoctorConfig.IDoctorMapper
    {
        public Doctor Map(DoctorDto.Request.Create p1)
        {
            return p1 == null ? null : new Doctor()
            {
                FirstName = p1.FirstName,
                LastName = p1.LastName,
                Surname = p1.Surname,
                Description = p1.Description,
                PhotoUrl = p1.PhotoUrl == null ? null : p1.PhotoUrl.ToString()
            };
        }
        public Doctor Map(DoctorDto.Request.Update p2)
        {
            return p2 == null ? null : new Doctor()
            {
                FirstName = p2.FirstName,
                LastName = p2.LastName,
                Surname = p2.Surname,
                Description = p2.Description,
                PhotoUrl = p2.PhotoUrl == null ? null : p2.PhotoUrl.ToString()
            };
        }
        public DoctorDto.Response.Details Map(Doctor p3)
        {
            return p3 == null ? null : new DoctorDto.Response.Details(p3.Id, p3.FirstName, p3.LastName, p3.Surname, p3.Description, p3.PhotoUrl == null ? null : new Uri(p3.PhotoUrl), funcMain1(p3.MedicalProfile), null);
        }
        
        private IReadOnlyCollection<DoctorDto.Response.MedicalProfile> funcMain1(ICollection<MedicalProfile> p4)
        {
            if (p4 == null)
            {
                return null;
            }
            IReadOnlyCollection<DoctorDto.Response.MedicalProfile> result = new List<DoctorDto.Response.MedicalProfile>(p4.Count);
            
            ICollection<DoctorDto.Response.MedicalProfile> list = (ICollection<DoctorDto.Response.MedicalProfile>)result;
            
            IEnumerator<MedicalProfile> enumerator = p4.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                MedicalProfile item = enumerator.Current;
                list.Add(item == null ? null : new DoctorDto.Response.MedicalProfile(item.Id, item.Name, item.Description));
            }
            return result;
            
        }
    }
}