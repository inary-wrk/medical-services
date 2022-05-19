using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datalayer.abstraction.Entities
{
    public class Doctor
    {
        public long Id { get; set; }
        public PersonInformation PersonInformation { get; set; }
        public string Description { get; set; }
        public string PhotoUrl { get; set; }
        public ICollection<MedicalProfile> MedicalProfile { get; set; }
        public ICollection<Clinic> Clinic { get; set; }
    }
}
