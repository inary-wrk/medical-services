namespace businesslogic.abstraction.ValueObjects
{
    public record Address
    {
        public string CountryISO { get; init; }
        public string Region { get; init; }
        public string City { get; init; }
        public string Street { get; init; }
        public int HouseNnumber { get; init; }
        public int? HouseBuilding { get; init; }
        public int? Appartament { get; init; }

        public Address(string countryISO,
                       string region,
                       string city,
                       string street,
                       int houseNnumber,
                       int? houseBuilding = null,
                       int? appartament = null)
        {
            CountryISO = countryISO;
            Region = region;
            City = city;
            Street = street;
            HouseNnumber = houseNnumber;
            HouseBuilding = houseBuilding;
            Appartament = appartament;
        }

    }
}