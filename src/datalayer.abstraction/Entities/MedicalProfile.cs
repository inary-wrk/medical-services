using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace datalayer.abstraction.Entities
{
    public class MedicalProfile : BaseEntity
    {
        // TODO: populate names
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        [NotMapped]
        public int DoctorCount { get; set; }

        public ICollection<Clinic> Clinics { get; set; } = null!;
        public ICollection<Doctor> Doctors { get; set; } = null!;
    }
}