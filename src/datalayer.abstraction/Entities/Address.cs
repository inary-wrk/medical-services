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
        [Required]
        public string CountryISO { get; set; }
        [Required]
        public string Region { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public int HouseNnumber { get; set; }
        public int HouseBuilding { get; set; }
        public int Appartament { get; set; }
    }
}
