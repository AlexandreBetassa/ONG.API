using AutoMapper;
using ONG.Api.Domain.Entities.v1.Persons;

namespace ONG.Api.Domain.Queries.v1.Persons.GetPersonByCpf
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
