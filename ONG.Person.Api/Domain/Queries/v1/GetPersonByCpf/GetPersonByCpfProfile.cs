using AutoMapper;
using ONG.Person.Api.Domain.Entities.v1;

namespace ONG.Person.Api.Domain.Queries.v1.GetPersonByCpf
{
    public class GetPersonByCpfProfile : Profile
    {
        public GetPersonByCpfProfile()
        {
            CreateMap<Entities.v1.Person, GetPersonByCpfQueryResponse>();
            CreateMap<Address, GetPersonAddressByCpfQueryResponse>();
            CreateMap<Contact, GetPersonContactByCpfQueryResponse>();
        }
    }
}
