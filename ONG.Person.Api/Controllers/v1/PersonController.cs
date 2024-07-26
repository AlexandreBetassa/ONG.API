using MediatR;
using Microsoft.AspNetCore.Mvc;
using ONG.Person.Api.Domain.Commands.v1.Person.CreatePerson;
using ONG.Person.Api.Domain.Commands.v1.Person.UpdatePerson;
using ONG.Person.Api.Domain.Queries.v1.Person.GetPersonByCpf;

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
            return Ok(await Mediator.Send(new GetPersonByCpfQuery(cpf)));
        }

        [HttpPut("{cpf}")]
        public async Task<IActionResult> UpdatePersonAsync([FromRoute] string cpf, [FromBody] UpdatePersonCommand request)
        {
            request.Cpf = cpf;  
            return Ok(await Mediator.Send(request));
        }
    }
}