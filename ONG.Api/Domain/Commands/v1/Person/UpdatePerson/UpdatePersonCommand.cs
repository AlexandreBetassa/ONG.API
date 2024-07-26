using MediatR;
using ONG.Api.Domain.Enums.v1;

namespace ONG.Api.Domain.Commands.v1.Person.UpdatePerson
{
    public class UpdatePersonCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Cpf { get; set; }
        public DateTime Birthday { get; set; }
        public UpdatePersonContactCommand Contact { get; set; }
        public UpdatePersonAddressCommand Address { get; set; }
    }
    public class UpdatePersonContactCommand
    {
        public string Number { get; set; }
        public TypeContactEnum TypeContact { get; set; }
    }

    public class UpdatePersonAddressCommand
    {
        public string PostalCode { get; set; }
        public string Street { get; set; }
        public string Neighborhood { get; set; }
        public int Number { get; set; }
        public string City { get; set; }
        public string? Complement { get; set; }
    }
}
