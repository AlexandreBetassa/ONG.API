using AutoMapper;

namespace ONG.Person.Api.Domain.Commands.v1.Pet.CreatePet
{
    public class CreatePetCommandProfile : Profile
    {
        public CreatePetCommandProfile()
        {
            CreateMap<CreatePetCommand, Entities.v1.Pet.Pet>()
                .ForMember(dest => dest.Photo, src => src.MapFrom(opt => ConvertToByteArray(opt.PhotoFile)));
        }

        private byte[] ConvertToByteArray(IFormFile file)
        {
            if (file == null) return null;

            using (var ms = new MemoryStream())
            {
                file.CopyTo(ms);
                return ms.ToArray();
            }
        }
    }
}
