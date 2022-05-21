using businesslogic.abstraction.TinyTypes;

namespace businesslogic.abstraction.Dto
{
    public record Person
    {
        public Id PersonId { get; set; }
        public PersonName FirstName { get; set; }
        public PersonName LastName { get; set; }
        public PersonName? Surname { get; set; }

        public Person(PersonName firstName, PersonName lastName, PersonName? surname = null)
        {
            FirstName = firstName;
            LastName = lastName;
            Surname = surname;
        }
    }
}
