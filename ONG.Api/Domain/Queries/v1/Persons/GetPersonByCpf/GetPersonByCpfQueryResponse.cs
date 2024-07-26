using ONG.Api.Domain.Enums.v1;

namespace ONG.Api.Domain.Queries.v1.Persons.GetPersonByCpf
{
    public class GetPersonByCpfQueryResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Cpf { get; set; }
        public DateTime Birthday { get; set; }
        public GetPersonContactByCpfQueryResponse Contact { get; set; }
        public GetPersonAddressByCpfQueryResponse Address { get; set; }
    }

    public class GetPersonContactByCpfQueryResponse
    {
        public Guid Id { get; set; }
        public string Number { get; set; }
        public TypeContactEnum TypeContact { get; set; }
    }

    public class GetPersonAddressByCpfQueryResponse
    {
        public Guid Id { get; set; }
        public string PostalCode { get; set; }
        public string Street { get; set; }
        public string Neighborhood { get; set; }
        public int Number { get; set; }
        public string City { get; set; }
        public string? Complement { get; set; }
    }
}