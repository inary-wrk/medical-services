using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datalayer.abstraction.Entities
{
    public class Address
    {
        public long Id { get; set; }
        public string CountryISO { get; set; }
        public string Region { get; set; }
        public string City { get; set; }
        public int Street { get; set; }
        public int HouseNnumber { get; set; }
        public int HouseBuilding { get; set; }
        public MapPoint MapPoint { get; set; }

        public long ClinicId { get; set; }
        public Clinic Clinic { get; set; }
    }
}
