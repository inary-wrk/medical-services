using System.ComponentModel.DataAnnotations;

namespace datalayer.abstraction.Entities
{
    public class Address
    {
        public string CountryISO { get; set; } = null!;
        public string Region { get; set; } = null!;
        public string City { get; set; } = null!;
        public string Street { get; set; } = null!;
        public int HouseNnumber { get; set; }
        public int? HouseBuilding { get; set; }
        public int? Appartament { get; set; }
    }
}
