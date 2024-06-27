using MediatR;
using Microsoft.AspNetCore.Mvc;
using ONG.Person.Api.Domain.Commands.v1.Pet.CreatePet;

namespace ONG.Person.Api.Controllers.v1
{
    [Route("api/v1/pets")]
    [ApiController]
    public class PetController : BaseController
    {
        public PetController(IMediator mediator, ILoggerFactory logger) 
            : base(mediator, logger)
        {
        }

        [HttpPost]
        public async Task<IActionResult> CreatePetAsync([FromForm] CreatePetCommand request)
        {
            await Mediator.Send(request);   

            return Created();
        }
    }
}
