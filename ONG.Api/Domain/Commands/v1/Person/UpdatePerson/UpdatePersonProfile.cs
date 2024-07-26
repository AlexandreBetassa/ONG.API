using AutoMapper;
using ONG.Api.Domain.Entities.v1.Persons;

namespace ONG.Api.Domain.Commands.v1.Person.UpdatePerson
{
    public class UpdatePersonProfile : Profile
    {
        public UpdatePersonProfile()
        {
            CreateMap<UpdatePersonCommand, Entities.v1.Persons.Person>();
            CreateMap<UpdatePersonContactCommand, Contact>();
            CreateMap<UpdatePersonAddressCommand, Address>();
        }
    }
}
