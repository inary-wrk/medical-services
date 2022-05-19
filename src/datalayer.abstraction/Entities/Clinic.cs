using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datalayer.abstraction.Entities
{
    public class Clinic
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public Address Address { get; set; }
        public string Description { get; set; }
        public ICollection<Uri> PhotoUrl { get; set; }
        public ICollection<Doctor> Doctor { get; set; }
        public ICollection<MedicalProfile> MedicalProfile { get; set; }
    }
}
