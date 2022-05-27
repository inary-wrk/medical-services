using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace datalayer.abstraction.Entities
{
    public class MedicalProfile : BaseEntity
    {
        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Clinic> Clinic { get; set; }
        public ICollection<Doctor> Doctors { get; set; }
    }
}