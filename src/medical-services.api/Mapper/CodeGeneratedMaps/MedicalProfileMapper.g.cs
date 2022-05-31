using System;
using System.Collections.Generic;
using businesslogic.abstraction.Dto;
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
        public MedicalProfileDto.Response.Details Map(MedicalProfile p3)
        {
            return p3 == null ? null : new MedicalProfileDto.Response.Details(p3.Name, p3.Description, funcMain1(p3.Clinic), funcMain2(p3.Doctor));
        }
        
        private IReadOnlyCollection<MedicalProfileDto.Response.Clinic> funcMain1(ICollection<Clinic> p4)
        {
            if (p4 == null)
            {
                return null;
            }
            IReadOnlyCollection<MedicalProfileDto.Response.Clinic> result = new List<MedicalProfileDto.Response.Clinic>(p4.Count);
            
            ICollection<MedicalProfileDto.Response.Clinic> list = (ICollection<MedicalProfileDto.Response.Clinic>)result;
            
            IEnumerator<Clinic> enumerator = p4.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                Clinic item = enumerator.Current;
                list.Add(item == null ? null : new MedicalProfileDto.Response.Clinic(item.Id, item.Name, item.Description));
            }
            return result;
            
        }
        
        private IReadOnlyCollection<MedicalProfileDto.Response.Doctor> funcMain2(ICollection<Doctor> p5)
        {
            if (p5 == null)
            {
                return null;
            }
            IReadOnlyCollection<MedicalProfileDto.Response.Doctor> result = new List<MedicalProfileDto.Response.Doctor>(p5.Count);
            
            ICollection<MedicalProfileDto.Response.Doctor> list = (ICollection<MedicalProfileDto.Response.Doctor>)result;
            
            IEnumerator<Doctor> enumerator = p5.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                Doctor item = enumerator.Current;
                list.Add(item == null ? null : new MedicalProfileDto.Response.Doctor(item.Id, item.FirstName, item.LastName, item.Surname, item.Description, item.PhotoUrl == null ? null : new Uri(item.PhotoUrl)));
            }
            return result;
            
        }
    }
}