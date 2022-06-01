using System;
using System.Collections.Generic;

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
            public record Details(string Name,
                                  string? Description,
                                  int DoctorsCount);
        }
    }
}
