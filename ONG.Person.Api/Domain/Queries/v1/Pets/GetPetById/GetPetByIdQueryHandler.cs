using AutoMapper;
using MediatR;
using ONG.Person.Api.Domain.Commands.v1;
using ONG.Person.Api.Domain.Interfaces.v1;

namespace ONG.Person.Api.Domain.Queries.v1.Pets.GetPetById
{
    public class GetPetByIdQueryHandler : BaseCommandhandler, IRequestHandler<GetPetByIdQuery, GetPetByIdQueryResponse>
    {
        public GetPetByIdQueryHandler(ILoggerFactory loggerFactory, IMapper mapper, IUnityOfWork unityOfWork)
            : base(mapper, unityOfWork)
        {
            Logger = loggerFactory.CreateLogger<GetPetByIdQueryHandler>();
        }

        public async Task<GetPetByIdQueryResponse> Handle(GetPetByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                Logger.LogInformation($"Iniciando metodo {nameof(GetPetByIdQueryHandler)}.{nameof(Handle)} || PetID={request.Id}");

                var pet = await UnityOfWork.PetRepository.GetById(request.Id);

                if (pet is null)
                {
                    Logger.LogInformation($"Metodo {nameof(GetPetByIdQueryHandler)}.{nameof(Handle)} || PetID={request.Id} - Não localizado");

                    throw new ArgumentNullException("Pet não localizado!!!");
                }

                var response = Mapper.Map<GetPetByIdQueryResponse>(pet);

                Logger.LogInformation($"Fim metodo{nameof(GetPetByIdQueryHandler)}.{nameof(Handle)} || PetID={request.Id}");

                return response;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, $"Metodo{nameof(GetPetByIdQueryHandler)}.{nameof(Handle)} || PetID={request.Id}");

                throw;
            }
        }
    }
}
