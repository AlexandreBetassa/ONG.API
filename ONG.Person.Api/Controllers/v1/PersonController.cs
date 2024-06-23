using MediatR;
using Microsoft.AspNetCore.Mvc;
using ONG.Person.Api.Domain.Commands.v1.Person.CreatePerson;

namespace ONG.Person.Api.Controllers.v1
{
    [Route("api/v1/persons")]
    [ApiController]
    public class PersonController : BaseController
    {
        public PersonController(IMediator mediator, ILoggerFactory logger)
            : base(mediator, logger)
        {
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreatePersonCommand request)
        {
            await Mediator.Send(request);

            return Ok();
        }

        [HttpGet("{cpf}")]
        public async Task<IActionResult> GetByCpfAsync([FromRoute] string cpf)
        {
            //await Mediator.Send();

            return Ok();
        }
    }
}
