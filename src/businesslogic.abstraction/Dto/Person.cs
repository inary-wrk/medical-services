using businesslogic.abstraction.ValueObjects;

namespace businesslogic.abstraction.Dto
{
    public record Person
    {
        public Id PersonId { get; set; }
        public PersonName Name { get; set; }

        public Person(Id personId, PersonName name)
        {
            PersonId = personId;
            Name = name;
        }
    }
}
