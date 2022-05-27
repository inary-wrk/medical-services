using System;
using System.Collections.Generic;
using businesslogic.abstraction.ValueObjects;

namespace businesslogic.abstraction.Dto
{
    public static class ClinicDto
    {
        public record Clinic(Id Id,
                              ValueObjects.ClinicName Name,
                              ValueObjects.Address Address,
                              ValueObjects.ClinicDescription Description,
                              List<DoctorDto.Doctor> Doctor,
                              List<MedicalProfileDto.MedicalProfile> MedicalProfile,
                              MapPointDto? MapPoint,
                              Uri? PhotoUrl);

        public static class ValueObjects
        {
            public record ClinicName(string Name);
            public record ClinicDescription(string Description);
            public record Address(string CountryISO,
                                  string Region,
                                  string City,
                                  string Street,
                                  int HouseNnumber,
                                  int? HouseBuilding,
                                  int? Appartament);
        }
    }
}