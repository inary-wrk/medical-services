using System;
using System.Collections.Generic;
using businesslogic.abstraction.ValueObjects;

namespace businesslogic.abstraction.Dto
{
    public static class ClinicDto
    {
        public static class Request
        {
            public record Create(string Name,
                                 string? Description,
                                 CreateAddress Address,
                                 MapPointDto? MapPoint,
                                 Uri? PhotoUrl);

            public record Update(string? Name,
                                 string? Description,
                                 UpdateAddress? Address,
                                 MapPointDto? MapPoint,
                                 Uri? PhotoUrl);

            public record CreateAddress(string CountryISO,
                                        string Region,
                                        string City,
                                        string Street,
                                        int HouseNnumber,
                                        int? HouseBuilding,
                                        int? Appartament);

            public record UpdateAddress(string? CountryISO,
                                        string? Region,
                                        string? City,
                                        string? Street,
                                        int? HouseNnumber,
                                        int? HouseBuilding,
                                        int? Appartament);
        }

        public static class Response
        {
            public record MedicalProfile(long Id,
                                         string Name,
                                         string? Description);

            public record Doctor(long Id,
                                 string FirstName,
                                 string LastName,
                                 string? Surname,
                                 string? Description,
                                 string? PhotoUrl,
                                 IReadOnlyList<MedicalProfile> MedicalProfiles);

            public record CityCode(string City, string Code);
            
            public record Details(long Id,
                                  string Name,
                                  string? Description,
                                  Address Address,
                                  MapPointDto? MapPoint,
                                  string? PhotoUrl,
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