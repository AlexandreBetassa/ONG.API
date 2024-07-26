using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ONG.Api.Controllers.v1
{
    public abstract class BaseController(IMediator mediator, ILoggerFactory logger) : ControllerBase
    {
        public IMediator Mediator { get; set; } = mediator;
        public ILoggerFactory Logger { get; set; } = logger;
    }
}
