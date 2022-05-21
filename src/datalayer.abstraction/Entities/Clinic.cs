using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datalayer.abstraction.Entities
{
    public class Clinic
    {
        public long Id { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }
        [Required]
        public Address Address { get; set; }
        public MapPoint MapPoint { get; set; }
        public string Description { get; set; }
        public string PhotoUrl { get; set; }
        public ICollection<Doctor> Doctor { get; set; }
        public ICollection<MedicalProfile> MedicalProfile { get; set; }

    }
}
