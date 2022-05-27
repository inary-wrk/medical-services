using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace datalayer.abstraction.Entities
{
    public class Doctor : BaseEntity
    {
        [Required(AllowEmptyStrings = false)]
        public string FirstName { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string LastName { get; set; }
        public string Surname { get; set; }
        public string Description { get; set; }
        public string PhotoUrl { get; set; }

        public ICollection<MedicalProfile> MedicalProfile { get; set; }
        public ICollection<Clinic> Clinic { get; set; }
    }
}
