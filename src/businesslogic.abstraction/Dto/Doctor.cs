using System;
using System.Collections.Generic;
using businesslogic.abstraction.TinyTypes;

namespace businesslogic.abstraction.Dto
{
    public record Doctor : Person
    {
        public Id DoctorId { get; set; }
        public DoctorDescription? Description { get; set; }
        public Uri? PhotoUrl { get; set; }
        public ICollection<MedicalProfile> MedicalProfile { get; set; }
        public ICollection<Clinic> Clinic { get; set; }

        public Doctor(
            Id id,
            PersonName firstName,
            PersonName lastName,
            ICollection<MedicalProfile> medicalProfile,
            ICollection<Clinic> clinic
            ) : base(firstName, lastName)
        {
            DoctorId = id;
            MedicalProfile = medicalProfile;
            Clinic = clinic;
        }
    }
}
