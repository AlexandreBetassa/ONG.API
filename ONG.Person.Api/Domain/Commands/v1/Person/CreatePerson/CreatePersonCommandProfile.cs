using AutoMapper;
using ONG.Person.Api.Domain.Entities.v1.Persons;

namespace ONG.Person.Api.Domain.Commands.v1.Person.CreatePerson
{
    public class CreatePersonCommandProfile : Profile
    {
        public CreatePersonCommandProfile()
        {
            CreateMap<CreatePersonCommand, Entities.v1.Persons.Person>(MemberList.Destination);
            CreateMap<CreatePersonAddressCommand, Address>(MemberList.Destination);
            CreateMap<CreatePersonContactCommand, Contact>(MemberList.Destination);
        }
    }
}