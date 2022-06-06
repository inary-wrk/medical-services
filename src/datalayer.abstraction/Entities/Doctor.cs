using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace datalayer.abstraction.Entities
{
    public class Doctor : BaseEntity
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? Surname { get; set; }
        public string? Description { get; set; }
        public string? PhotoUrl { get; set; }

        public ICollection<MedicalProfile> MedicalProfiles { get; set; } = null!;
        public ICollection<ClinicDoctor> ClinicsLink { get; set; } = null!;
    }
}
