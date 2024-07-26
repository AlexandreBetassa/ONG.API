using MediatR;
using Microsoft.AspNetCore.Mvc;

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


    }
}
