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
            return p3 == null ? null : new MedicalProfileDto.Response.Details(p3.Name, p3.Description, funcMain1(p3.Doctors == null ? null : (int?)p3.Doctors.Count));
        }
        public IReadOnlyList<MedicalProfileDto.Response.Details> Map(IReadOnlyList<ValueTuple<MedicalProfile, int>> p5)
        {
            if (p5 == null)
            {
                return null;
            }
            IReadOnlyList<MedicalProfileDto.Response.Details> result = new List<MedicalProfileDto.Response.Details>();
            
            ICollection<MedicalProfileDto.Response.Details> list = (ICollection<MedicalProfileDto.Response.Details>)result;
            
            IEnumerator<ValueTuple<MedicalProfile, int>> enumerator = p5.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                ValueTuple<MedicalProfile, int> item = enumerator.Current;
                list.Add(new MedicalProfileDto.Response.Details(item.Item1.Name, item.Item1.Description, item.Item2));
            }
            return result;
            
        }
        
        private int funcMain1(int? p4)
        {
            return p4 == null ? 0 : (int)p4;
        }
    }
}