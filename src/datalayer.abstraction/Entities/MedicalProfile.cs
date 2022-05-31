using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace datalayer.abstraction.Entities
{
    public class MedicalProfile : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; } 

        public ICollection<Clinic> Clinic { get; set; } = null!;
        public ICollection<Doctor> Doctor { get; set; } = null!;
    }
}