using AutoMapper;
using MediatR;
using ONG.Person.Api.Domain.Interfaces.v1.Repositories;

namespace ONG.Person.Api.Domain.Commands.v1.Person.UpdatePerson
{
    public class UpdatePersonCommandHandler : BaseCommandHandler, IRequestHandler<UpdatePersonCommand, Unit>
    {
        public UpdatePersonCommandHandler(ILoggerFactory loggerFactory, IMapper mapper, IUnityOfWork unityOfWork)
            : base(mapper, unityOfWork)
        {
            Logger = loggerFactory.CreateLogger<UpdatePersonCommandHandler>();
        }

        public async Task<Unit> Handle(UpdatePersonCommand request, CancellationToken cancellationToken)
        {
            try
            {
                Logger.LogInformation($"Iniciando metodo {nameof(UpdatePersonCommandHandler)}.{nameof(Handle)}");

                var person = await UnityOfWork.PersonRepository.GetByCpf(request.Cpf) 
                    ?? throw new ArgumentException("usuário nao localizado");

                person = Mapper.Map<Entities.v1.Persons.Person>(request);

                await UnityOfWork.PersonRepository.Update(person);

                Logger.LogInformation($"Fim {nameof(UpdatePersonCommandHandler)}.{nameof(Handle)}");

                return Unit.Value;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, $"Metodo {nameof(UpdatePersonCommandHandler)}.{nameof(Handle)}");
                throw;
            }
        }
    }
}
