using System;
using System.Collections.Generic;
using businesslogic.abstraction.ValueObjects;

namespace businesslogic.abstraction.Dto
{
    public static class MedicalProfileDto
    {
        public static class Request
        {
            public record Create(string Name, string? Description);

            public record Update(string? Name, string? Description);
        }

        public static class Response
        {
            public record Doctor(long Id,
                                 string FirstName,
                                 string LastName,
                                 string? Surname,
                                 string? Description,
                                 Uri? PhotoUrl);

            public record Clinic(long Id,
                                 string Name,
                                 string? Description,
                                 Address Address,
                                 MapPointDto? MapPoint,
                                 Uri? PhotoUrl);

            public record Details(long Id,
                                  string Name,
                                  string? Description,
                                  int? DoctorsCount);

            public record GetByIdDetails(long Id,
                                         string Name,
                                         string? Description,
                                         IReadOnlyList<Clinic> Clinics,
                                         IReadOnlyList<Doctor> Doctors);

            public record Address(string CountryISO,
                                  string Region,
                                  string City,
                                  string CityCode,
                                  string Street,
                                  int HouseNnumber,
                                  int? HouseBuilding,
                                  int? Appartament);
        }
    }
}
