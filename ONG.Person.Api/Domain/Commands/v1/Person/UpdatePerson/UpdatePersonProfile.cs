using AutoMapper;
using ONG.Person.Api.Domain.Entities.v1;

namespace ONG.Person.Api.Domain.Commands.v1.Person.UpdatePerson
{
    public class UpdatePersonProfile : Profile
    {
        public UpdatePersonProfile()
        {
            CreateMap<UpdatePersonCommand, Entities.v1.Person>();
            CreateMap<UpdatePersonContactCommand, Contact>();
            CreateMap<UpdatePersonAddressCommand, Address>();
        }
    }
}
