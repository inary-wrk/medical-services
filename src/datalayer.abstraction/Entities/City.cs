using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datalayer.abstraction.Entities
{
    public class City
    {
        public string Name { get; set; }
        public ICollection<Clinic> Clinics { get; set; }
    }
}
