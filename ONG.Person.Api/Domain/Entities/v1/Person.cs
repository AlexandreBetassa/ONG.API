namespace ONG.Person.Api.Domain.Entities.v1
{
    public class Person : BaseEntity
    {
        public Guid ContactId { get; set; }
        public Guid AddressId { get; set; }
        public string Name { get; set; }
        public string Cpf { get; set; }
        public DateTime Birthday { get; set; }
        public Contact Contact { get; set; }
        public Address Address { get; set; }
    }
}