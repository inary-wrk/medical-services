using System.ComponentModel.DataAnnotations;

namespace datalayer.abstraction.Entities
{
    public class Address
    {
        [Required(AllowEmptyStrings = false)]
        public string CountryISO { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Region { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string City { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Street { get; set; }
        [Required]
        public int HouseNnumber { get; set; }
        public int HouseBuilding { get; set; }
        public int Appartament { get; set; }
    }
}
