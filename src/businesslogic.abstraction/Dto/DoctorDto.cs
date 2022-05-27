using System;
using System.Collections.Generic;
using businesslogic.abstraction.ValueObjects;

namespace businesslogic.abstraction.Dto
{
    public static class DoctorDto
    {
        public static class Request
        {
            public record Create(string FirstName,
                                 string LastName,
                                 string? Surname,
                                 string? Description,
                                 Uri? PhotoUrl);
            //IList<string> MedicalProfile,
            //                   IList<string> Clinic);
        }

        public record Doctor(Id Id,
                             ValueObjects.FullName FullName,
                             ValueObjects.DoctorDescription Description,
                             Uri? PhotoUrl,
                             List<MedicalProfileDto.MedicalProfile> MedicalProfile,
                             List<ClinicDto.Clinic> Clinic);

        public static class ValueObjects
        {
            public record DoctorDescription(string Description);
            public record FullName(string FirstName,
                                   string LastName,
                                   string Surname);
        }
    }
}
