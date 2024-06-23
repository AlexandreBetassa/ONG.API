using AutoMapper;
using ONG.Person.Api.Domain.Entities.v1;

namespace ONG.Person.Api.Domain.Commands.v1.Person.CreatePerson
{
    public class CreatePersonCommandProfile : Profile
    {
        public CreatePersonCommandProfile()
        {
            CreateMap<CreatePersonCommand, Entities.v1.Person>(MemberList.Destination);
            CreateMap<PersonAddressCommand, Address>(MemberList.Destination);
            CreateMap<PersonContactCommand, Contact>(MemberList.Destination);
        }
    }
}