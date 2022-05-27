using System;
using System.Collections.Generic;

namespace medical_services.api.Controllers.ApiContracts
{
    public static class DoctorApi
    {
        public static class Request
        {
            public record CreateTest(string FirstName,
                                     string LastName,
                                     string? Surname,
                                     string? Description,
                                     Uri? PhotoUrl,
                                     IReadOnlyList<long> Clinic,
                                     IReadOnlyList<long> MedicalProfile);
        }

        public static class Response
        {
            public record DoctorId(long Id);
            public record Details(long Id,
                                  string FirstName,
                                  string LastName,
                                  string Surname,
                                  string Description,
                                  Uri? PhotoUrl,
                                  IReadOnlyCollection<MedicalProfile> MedicalProfile,
                                  IReadOnlyCollection<Clinic> Clinic);

            public record MedicalProfile(long Id,
                                         string Name,
                                         string Description);

            public record Clinic(long Id,
                                 string Name,
                                 string Description,
                                 string Address,
                                 MapPoint? MapPoint,
                                 Uri? PhotoUrl);

            public record MapPoint(double NorthLatitude,
                                   double WesternLongitude);
        }
    }
}