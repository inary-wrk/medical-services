using System.Collections.Generic;

namespace datalayer.abstraction.Entities
{
    public class MedicalProfile
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Clinic> Clinic { get; set; }
        public ICollection<Doctor> Doctors { get; set; }
    }
}