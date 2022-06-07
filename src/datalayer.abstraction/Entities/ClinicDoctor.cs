using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datalayer.abstraction.Entities
{
    public class ClinicDoctor
    {
        public long ClinicId { get; set; }
        public long DoctorId { get; set; }
        // TODO: doctor - clinic - medicalpofile
        public ICollection<MedicalProfile> MedicalProfiles { get; set; } = null!;
        public Clinic Clinic { get;  set; } = null!;
        public Doctor Doctor { get;  set; } = null!;
    }
}
