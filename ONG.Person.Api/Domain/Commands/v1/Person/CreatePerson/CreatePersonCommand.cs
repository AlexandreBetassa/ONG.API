using MediatR;
using ONG.Person.Api.Domain.Enums.v1;

namespace ONG.Person.Api.Domain.Commands.v1.Person.CreatePerson
{
    public class CreatePersonCommand : IRequest<Unit>
    {
        public string Name { get; set; }
        public string Cpf { get; set; }
        public DateTime Birthday { get; set; }
        public PersonContactCommand Contact { get; set; }
        public PersonAddressCommand Address { get; set; }
    }

    public class PersonContactCommand
    {
        public string Number { get; set; }
        public TypeContactEnum TypeContact { get; set; }
    }

    public class PersonAddressCommand
    {
        public string Street { get; set; }
        public string Neighborhood { get; set; }
        public int Number { get; set; }
        public string City { get; set; }
        public string? Complement { get; set; }
    }
}