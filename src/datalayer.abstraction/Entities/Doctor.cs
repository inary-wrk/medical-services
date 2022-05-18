using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using datalayer.abstraction.TinyTypes;

namespace datalayer.abstraction.Entities
{
    public class Doctor
    {
        public long Id { get; set; }
        public PersonName Name { get; set; }
        public string Description { get; set; }
        public Uri PhotoUrl { get; set; }
        public ICollection<MedicalProfile> MedicalProfile { get; set; }
        public ICollection<Clinic> Clinic { get; set; }
    }
}
