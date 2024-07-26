using AutoMapper;
using MediatR;
using ONG.Api.Domain.Commands.v1;
using ONG.Api.Domain.Interfaces.v1.Repositories;

namespace ONG.Api.Domain.Queries.v1.Persons.GetPersonByCpf
{
    public class GetPersonByCpfQueryHandler : BaseCommandHandler, IRequestHandler<GetPersonByCpfQuery, GetPersonByCpfQueryResponse>
    {

        public GetPersonByCpfQueryHandler(ILoggerFactory loggerFactory, IMapper mapper, IUnityOfWork unityOfWork)
            : base(mapper, unityOfWork)
        {
            Logger = loggerFactory.CreateLogger<GetPersonByCpfQueryHandler>();
        }

        public async Task<GetPersonByCpfQueryResponse> Handle(GetPersonByCpfQuery request, CancellationToken cancellationToken)
        {
            try
            {
                Logger.LogInformation($"Iniciando metodo {nameof(GetPersonByCpfQueryHandler)}.{nameof(Handle)}");

                var person = await UnityOfWork.PersonRepository.GetByCpf(request.Cpf)
                    ?? throw new ArgumentException("Usuário não localizado!");

                var response = Mapper.Map<GetPersonByCpfQueryResponse>(person);

                Logger.LogInformation($"Fim metodo {nameof(GetPersonByCpfQueryHandler)}.{nameof(Handle)}");

                return response;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, $"{nameof(GetPersonByCpfQueryHandler)}.{nameof(Handle)}");

                throw;
            }
        }
    }
}
