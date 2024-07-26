using MediatR;
using Microsoft.AspNetCore.Mvc;
using ONG.Api.Domain.Commands.v1.Person.CreatePerson;
using ONG.Api.Domain.Commands.v1.Person.UpdatePerson;
using ONG.Api.Domain.Queries.v1.Persons.GetPersonByCpf;

namespace ONG.Api.Controllers.v1
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