using MediatR;

namespace ONG.Person.Api.Domain.Commands.v1.Pet.CreatePet
{
    public class CreatePetCommand : IRequest<Unit>
    {
        public string? Name { get; set; }
        public string? Type { get; set; }
        public string? Gender { get; set; }
        public string? Castrated { get; set; }
        public string? Comments { get; set; }
        public IFormFile? PhotoFile { get; set; }
    }
}
