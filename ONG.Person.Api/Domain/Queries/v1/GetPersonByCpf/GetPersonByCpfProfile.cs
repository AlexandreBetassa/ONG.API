using AutoMapper;
using ONG.Person.Api.Domain.Entities.v1.Persons;

namespace ONG.Person.Api.Domain.Queries.v1.GetPersonByCpf
{
    public class GetPersonByCpfProfile : Profile
    {
        public GetPersonByCpfProfile()
        {
            CreateMap<Entities.v1.Persons.Person, GetPersonByCpfQueryResponse>();
            CreateMap<Address, GetPersonAddressByCpfQueryResponse>();
            CreateMap<Contact, GetPersonContactByCpfQueryResponse>();
        }
    }
}
