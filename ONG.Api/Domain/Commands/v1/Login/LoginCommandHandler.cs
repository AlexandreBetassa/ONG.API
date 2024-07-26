using AutoMapper;
using MediatR;
using ONG.Api.Domain.Interfaces.v1.Repositories;
using ONG.Api.Domain.Interfaces.v1.Services;

namespace ONG.Api.Domain.Commands.v1.Login
{
    public class LoginCommandHandler : BaseCommandHandler, IRequestHandler<LoginCommand, string>
    {
        private readonly IPasswordServices _passwordServices;
        private readonly ITokenService _tokenServices;

        public LoginCommandHandler(
            IMapper mapper,
            IUnityOfWork unityOfWork,
            IPasswordServices passwordServices,
            ITokenService tokenService)
            : base(mapper, unityOfWork)
        {
            _passwordServices = passwordServices;
            _tokenServices = tokenService;
        }

        public async Task<string> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var person = await UnityOfWork.PersonRepository.GetByEmailAsync(request.Email) ??
                throw new ArgumentException("Usuário não localizado");

            var isValidUser = _passwordServices.VerifyPassword(person, request.Password);

            if (!isValidUser)
                throw new UnauthorizedAccessException("Email/Senha inválidos");

            return _tokenServices.GenerateToken(person);
        }
    }
}
