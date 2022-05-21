using System;
using System.Collections.Generic;
using businesslogic.abstraction.TinyTypes;

namespace businesslogic.abstraction.Dto
{
    public record Clinic
    {
        public Id Id { get; set; }
        public ClinicName Name { get; set; }
        public Address Address { get; set; }
        public ClinicDescription Description { get; set; }
        public Uri? PhotoUrl { get; set; }
        public ICollection<Doctor> Doctor { get; set; }
        public ICollection<MedicalProfile> MedicalProfile { get; set; }

        public Clinic(ClinicName name, Address address, ClinicDescription description, ICollection<Doctor> doctor, ICollection<MedicalProfile> medicalProfile)
        {
            Name = name;
            Address = address;
            Description = description;
            Doctor = doctor;
            MedicalProfile = medicalProfile;
        }
    }
}