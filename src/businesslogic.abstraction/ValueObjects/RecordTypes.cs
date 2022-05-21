using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace businesslogic.abstraction.ValueObjects
{
    public record PersonName(string FirstName, string LastName, string Surname);
    public record DoctorDescription(string Description);
    public record MedicalProfileName(string Name);
    public record MedicalProfileDescription(string Description);
    public record ClinicName(string Name);
    public record ClinicDescription(string Description);
}
