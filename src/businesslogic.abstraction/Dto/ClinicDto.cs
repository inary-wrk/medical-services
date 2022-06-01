using System;
using businesslogic.abstraction.ValueObjects;

namespace businesslogic.abstraction.Dto
{
    public static class ClinicDto
    {
        public static class Request
        {
            public record Create(string Name,
                                 ValueObject.Address Address,
                                 MapPointDto? MapPoint,
                                 string? Description,
                                 Uri? PhotoUrl);

            public record Update(string? Name,
                                 ValueObject.UpdateAddress? Address,
                                 MapPointDto? MapPoint,
                                 string? Description,
                                 Uri? PhotoUrl);
        }

        public static class Response
        {
            public record Details(long Id,
                                  string Name,
                                  ValueObject.Address Address,
                                  MapPointDto? MapPoint,
                                  string? Description,
                                  Uri? PhotoUrl);
        }

        public static class ValueObject
        {
            public record Address(string CountryISO,
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
    }
}