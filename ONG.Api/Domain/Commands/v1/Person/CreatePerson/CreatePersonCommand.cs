using MediatR;
using ONG.Api.Domain.Enums.v1;

namespace ONG.Api.Domain.Commands.v1.Person.CreatePerson
{
    public class CreatePersonCommand : IRequest<Unit>
    {
        public string Name { get; set; }
        public string Cpf { get; set; }
        public DateTime Birthday { get; set; }
        public CreatePersonContactCommand Contact { get; set; }
        public CreatePersonAddressCommand Address { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string[] Roles { get; set; }
    }

    public class CreatePersonContactCommand
    {
        public string Number { get; set; }
        public TypeContactEnum TypeContact { get; set; }
    }

    public class CreatePersonAddressCommand
    {
        public string PostalCode { get; set; }
        public string Street { get; set; }
        public string Neighborhood { get; set; }
        public int Number { get; set; }
        public string City { get; set; }
        public string? Complement { get; set; }
    }
}