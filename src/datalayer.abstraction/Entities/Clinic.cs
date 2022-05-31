using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace datalayer.abstraction.Entities
{
    public class Clinic : BaseEntity
    {
        public string Name { get; set; } = null!;
        public Address Address { get; set; } = null!;
        public MapPoint? MapPoint { get; set; }
        public string? Description { get; set; }
        public string? PhotoUrl { get; set; }

        public ICollection<Doctor> Doctor { get; set; } = null!;
        public ICollection<MedicalProfile> MedicalProfile { get; set; } = null!;
    }
}
