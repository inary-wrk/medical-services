using System.Collections.Generic;
using businesslogic.abstraction.ValueObjects;

namespace businesslogic.abstraction.Dto
{
    public static class MedicalProfileDto
    {
        public record MedicalProfile(Id Id,
                                     ValueObjects.MedicalProfileName Name,
                                     ValueObjects.MedicalProfileDescription Description,
                                     List<ClinicDto.Clinic> Clinics,
                                     List<DoctorDto.Doctor> Doctors);

        public static class ValueObjects
        {
            public record MedicalProfileName(string Name);
            public record MedicalProfileDescription(string Description);
        }
    }
}
