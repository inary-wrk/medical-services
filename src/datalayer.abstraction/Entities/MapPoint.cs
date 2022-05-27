using System.ComponentModel.DataAnnotations;

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
