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

        public ICollection<MedicalProfile> MedicalProfile { get; set; } = null!;
        public ICollection<Clinic> Clinics { get; set; } = null!;
    }
}
