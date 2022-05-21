using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
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
        public double NorthLatitude { get; set; }
        public double WesternLongitude { get; set; }

        public long ClinicId { get; set; }
        public Clinic Clinic { get; set; }
    }
}
