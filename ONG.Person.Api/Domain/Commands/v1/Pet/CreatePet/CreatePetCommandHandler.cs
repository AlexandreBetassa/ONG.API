using AutoMapper;
using MediatR;
using ONG.Person.Api.Domain.Interfaces.v1;

namespace ONG.Person.Api.Domain.Commands.v1.Pet.CreatePet
{
    public class CreatePetCommandHandler : BaseCommandhandler, IRequestHandler<CreatePetCommand, Unit>
    {
        public CreatePetCommandHandler(ILoggerFactory loggerFactory, IMapper mapper, IUnityOfWork unityOfWork)
            : base(mapper, unityOfWork)
        {
            Logger = loggerFactory.CreateLogger<CreatePetCommandHandler>();
        }

        public async Task<Unit> Handle(CreatePetCommand request, CancellationToken cancellationToken)
        {
            try
            {
                Logger.LogInformation($"Iniciando metodo {nameof(CreatePetCommandHandler)}.{nameof(Handle)}");

                var pet = Mapper.Map<Entities.v1.Pet.Pet>(request);

                await UnityOfWork.PetRepository.Create(pet);
                await UnityOfWork.SaveAsync();

                Logger.LogInformation($"Fim metodo {nameof(CreatePetCommandHandler)}.{nameof(Handle)}");

                return Unit.Value;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, $"Metodo {nameof(CreatePetCommandHandler)}.{nameof(Handle)}");

                throw;
            }
        }
    }
}