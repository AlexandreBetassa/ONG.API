using AutoMapper;
using MediatR;
using ONG.Api.Domain.Interfaces.v1.Repositories;
using ONG.Api.Domain.Interfaces.v1.Services;

namespace ONG.Api.Domain.Commands.v1.Person.CreatePerson
{
    public class CreatePersonCommandHandler : BaseCommandHandler, IRequestHandler<CreatePersonCommand, Unit>
    {
        private readonly IPasswordServices _passwordServices;

        public CreatePersonCommandHandler(ILoggerFactory loggerFactory, IMapper mapper, IUnityOfWork unityOfWork, IPasswordServices passwordServices)
            : base(mapper, unityOfWork)
        {
            Logger = loggerFactory.CreateLogger<CreatePersonCommandHandler>();
            _passwordServices = passwordServices;
        }

        public async Task<Unit> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
        {
            try
            {
                Logger.LogInformation($"Iniciando metodo {nameof(CreatePersonCommandHandler)}.{nameof(Handle)}");

                var existingRegister = await UnityOfWork.PersonRepository.GetByCpf(request.Cpf);

                if (existingRegister != null)
                {
                    Logger.LogInformation($"{nameof(CreatePersonCommandHandler)}.{nameof(Handle)} | Usuário já cadastrado!!!");

                    throw new ArgumentException("usuário já cadastrado!!!");
                }

                var person = Mapper.Map<Entities.v1.Persons.Person>(request);
                person.Password = _passwordServices.HashPassword(person);

                await UnityOfWork.PersonRepository.Create(person);

                Logger.LogInformation($"Finalizando metodo {nameof(CreatePersonCommandHandler)}.{nameof(Handle)}");

                return Unit.Value;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, $"Metodo {nameof(CreatePersonCommandHandler)}.{nameof(Handle)}");

                throw;
            }
        }
    }
}