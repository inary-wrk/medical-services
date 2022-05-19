using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datalayer.abstraction.Entities
{
    public class MapPoint
    {
        public double NorthLatitude { get; set; }
        public double WesternLongitude { get; set; }

        public long ClinicId { get; set; }
        public Address Address { get; set; }
    }
}
