namespace ONG.Api.Domain.Entities.v1.Persons
{
    public class Address : BaseEntity
    {
        public string PostalCode { get; set; }
        public string Street { get; set; }
        public string Neighborhood { get; set; }
        public int Number { get; set; }
        public string City { get; set; }
        public string? Complement { get; set; }
    }
}