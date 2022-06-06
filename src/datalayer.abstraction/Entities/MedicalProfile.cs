using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace datalayer.abstraction.Entities
{
    public class MedicalProfile : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }

        public ICollection<ClinicDoctor> ClinicDoctors { get; set; } = null!;
        public ICollection<Doctor> Doctors { get; set; } = null!;
    }
}