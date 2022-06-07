using System;
using System.Collections.Generic;
using businesslogic.abstraction.ValueObjects;

namespace businesslogic.abstraction.Dto
{
    public static partial class DoctorDto
    {
        public static class Request
        {
            public record Create(string FirstName,
                                 string LastName,
                                 string? Surname,
                                 string? Description,
                                 Uri? PhotoUrl);

            public record Update(string? FirstName,
                                 string? LastName,
                                 string? Surname,
                                 string? Description,
                                 Uri? PhotoUrl);
        }

        public static class Response
        {
            public record Address(string CountryISO,
                                  string Region,
                                  string City,
                                  string CityCode,
                                  string Street,
                                  int HouseNnumber,
                                  int? HouseBuilding,
                                  int? Appartament);

            public record Details(long Id,
                                  string FirstName,
                                  string LastName,
                                  string Surname,
                                  string Description,
                                  string PhotoUrl,
                                  IReadOnlyCollection<MedicalProfile> MedicalProfiles,
                                  IReadOnlyCollection<Clinic> Clinics);

            public record MedicalProfile(long Id,
                                        string Name,
                                        string Description);

            public record Clinic(long Id,
                                 string Name,
                                 string Description,
                                 Address Address,
                                 MapPointDto? MapPoint,
                                 string PhotoUrl,
                                 IReadOnlyCollection<MedicalProfile> MedicalProfile);
        }
    }
}
