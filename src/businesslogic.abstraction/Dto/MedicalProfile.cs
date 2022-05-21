using System.Collections.Generic;
using businesslogic.abstraction.TinyTypes;

namespace businesslogic.abstraction.Dto
{
    public record MedicalProfile
    {
        public Id Id { get; set; }
        public MedicalProfileName Name { get; set; }
        public MedicalProfileDescription? Description { get; set; }
        public ICollection<Clinic> Clinic { get; set; }
        public ICollection<Doctor> Doctors { get; set; }

        public MedicalProfile(MedicalProfileName name, ICollection<Doctor> doctors, ICollection<Clinic> clinic)
        {
            Name = name;
            Doctors = doctors;
            Clinic = clinic;
        }
    }
}
