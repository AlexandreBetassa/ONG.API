using AutoMapper;
using ONG.Person.Api.Domain.Entities.v1.Pet;

namespace ONG.Person.Api.Domain.Queries.v1.Pets.GetPetById
{
    public class GetPetByIdQueryProfile : Profile
    {
        public GetPetByIdQueryProfile()
        {
            CreateMap<Pet, GetPetByIdQueryResponse>()
                .ForMember(dest => dest.Photo, src => src.MapFrom(opt => opt.Photo));
        }
    }
}