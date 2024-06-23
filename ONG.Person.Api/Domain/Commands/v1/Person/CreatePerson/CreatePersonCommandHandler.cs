using AutoMapper;
using MediatR;
using ONG.Person.Api.Domain.Commands.v1;
using ONG.Person.Api.Domain.Interfaces.v1;

namespace ONG.Person.Api.Domain.Commands.v1.Person.CreatePerson
{
    public class CreatePersonCommandHandler : BaseCommandhandler, IRequestHandler<CreatePersonCommand, Unit>
    {
        public CreatePersonCommandHandler(ILoggerFactory loggerFactory, IMapper mapper, IUnityOfWork unityOfWork)
            : base(mapper, unityOfWork)
        {
            Logger = loggerFactory.CreateLogger<CreatePersonCommandHandler>();
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

                var person = Mapper.Map<Entities.v1.Person>(request);

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