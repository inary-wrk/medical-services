using System;
using System.Collections.Generic;
using businesslogic.abstraction.ValueObjects;

namespace businesslogic.abstraction.Dto
{
    public record Doctor : Person
    {
        public Id DoctorId { get; set; }
        public DoctorDescription? Description { get; set; }
        public List<MedicalProfile> MedicalProfile { get; set; }
        public List<Clinic> Clinic { get; set; }
        public Uri? PhotoUrl { get; set; }

        public Doctor(
            Id doctorId,
            Id personId,
            PersonName name,
            List<MedicalProfile> medicalProfile,
            List<Clinic> clinic, 
            Uri? photoUrl = null) : base(personId, name)
        {
            DoctorId = doctorId;
            MedicalProfile = medicalProfile;
            Clinic = clinic;
            PhotoUrl = photoUrl;
        }
    }
}
