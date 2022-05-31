using System;
using System.Collections.Generic;

namespace businesslogic.abstraction.Dto
{
    public static class MedicalProfileDto
    {
        public static class Request
        {
            public record Create(string Name, string? Description);

            public record Update(long Id, string Name, string? Description);
        }

        public static class Response
        {
            public record Details(string Name,
                                  string? Description,
                                  IReadOnlyCollection<Clinic> Clinic,
                                  IReadOnlyCollection<Doctor> Doctor);

            public record Clinic(long Id, string Name, string? Description);
            public record Doctor(long Id,
                                 string FirstName,
                                 string LastName,
                                 string? Surname,
                                 string? Description,
                                 Uri? PhotoUrl);
        }
    }
}
