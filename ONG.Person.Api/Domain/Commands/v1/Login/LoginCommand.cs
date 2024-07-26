using MediatR;

namespace ONG.Person.Api.Domain.Commands.v1.Login
{
    public class LoginCommand : IRequest<string>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
