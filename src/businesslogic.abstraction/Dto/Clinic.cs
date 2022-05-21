using System;
using System.Collections.Generic;
using businesslogic.abstraction.ValueObjects;

namespace businesslogic.abstraction.Dto
{
    public record Clinic
    {
        public Id Id { get; set; }
        public ClinicName Name { get; set; }
        public Address Address { get; set; }
        public ClinicDescription Description { get; set; }
        public List<Doctor> Doctor { get; set; }
        public List<MedicalProfile> MedicalProfile { get; set; }
        public MapPoint? MapPoint { get; set; }
        public Uri? PhotoUrl { get; set; }

        public Clinic(ClinicName name,
                      Id id,
                      Address address,
                      ClinicDescription description,
                      List<Doctor> doctor,
                      List<MedicalProfile> medicalProfile,
                      MapPoint? mapPoint = null,
                      Uri? photoUrl = null)
        {
            Id = id;
            Name = name;
            Address = address;
            Description = description;
            Doctor = doctor;
            MedicalProfile = medicalProfile;
            MapPoint = mapPoint;
            PhotoUrl = photoUrl;
        }
    }
}