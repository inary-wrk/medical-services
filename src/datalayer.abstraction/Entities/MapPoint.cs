using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datalayer.abstraction.Entities
{
    public class MapPoint
    {
        [Required]
        public double NorthLatitude { get; set; }
        [Required]
        public double WesternLongitude { get; set; }
    }
}
