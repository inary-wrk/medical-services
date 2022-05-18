using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using datalayer.abstraction.TinyTypes;

namespace datalayer.abstraction.Entities
{
    public class Clinic
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public MapPoint MapPoint { get; set; }
        public ICollection<City> City { get; set; }
        public string Description { get; set; }
        public ICollection<Doctor> Doctors { get; set; }
        public ICollection<MedicalProfile> MedicalProfiles { get; set; }
    }
}
