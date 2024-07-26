using MediatR;
using Microsoft.AspNetCore.Mvc;
using ONG.Person.Api.Domain.Commands.v1.Login;

namespace ONG.Person.Api.Controllers.v1
{
    [Route("api/v1/login")]
    [ApiController]
    public class LoginController : BaseController
    {
        public LoginController(IMediator mediator, ILoggerFactory logger) 
            : base(mediator, logger)
        {
        }

        [HttpPost]
        public async Task<IActionResult> GenerateToken([FromBody] LoginCommand request)
        {
            var token = await Mediator.Send(request);

            return Ok(token);
        }
    }
}