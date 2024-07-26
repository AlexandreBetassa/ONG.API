using AutoMapper;
using MediatR;
using ONG.Person.Api.Domain.Interfaces.v1.Repositories;
using ONG.Person.Api.Domain.Interfaces.v1.Services;

namespace ONG.Person.Api.Domain.Commands.v1.Login
{
    public class LoginCommandHandler : BaseCommandHandler, IRequestHandler<LoginCommand, string>
    {
        private readonly IPasswordServices _passwordServices;

        public LoginCommandHandler(IMapper mapper, IUnityOfWork unityOfWork, IPasswordServices passwordServices) 
            : base(mapper, unityOfWork)
        {
            _passwordServices = passwordServices;
        }

        public async Task<string> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var person = await UnityOfWork.PersonRepository.GetByEmailAsync(request.Email) ??
                throw new ArgumentException("Usuário não localizado");

            var isValidUser = _passwordServices.VerifyPassword(person, request.Password);

            if (!isValidUser)
                throw new UnauthorizedAccessException("Email/Senha inválidos");


            throw new NotImplementedException();
        }
    }
}
