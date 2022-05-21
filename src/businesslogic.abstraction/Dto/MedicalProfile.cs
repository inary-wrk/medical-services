using System.Collections.Generic;
using businesslogic.abstraction.ValueObjects;

namespace businesslogic.abstraction.Dto
{
    public record MedicalProfile
    {
        public Id Id { get; set; }
        public MedicalProfileName Name { get; set; }
        public List<Clinic> Clinic { get; set; }
        public List<Doctor> Doctors { get; set; }
        public MedicalProfileDescription? Description { get; set; }

        public MedicalProfile(Id id, MedicalProfileName name, List<Doctor> doctors, List<Clinic> clinic, MedicalProfileDescription? description = null)
        {
            Name = name;
            Doctors = doctors;
            Clinic = clinic;
            Id = id;
            Description = description;
        }
    }
}
