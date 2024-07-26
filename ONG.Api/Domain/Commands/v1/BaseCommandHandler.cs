using AutoMapper;
using ONG.Api.Domain.Interfaces.v1.Repositories;

namespace ONG.Api.Domain.Commands.v1
{
    public abstract class BaseCommandHandler(IMapper mapper, IUnityOfWork unityOfWork)
    {
        public ILogger Logger { get; set; }
        public IMapper Mapper { get; } = mapper;
        public IUnityOfWork UnityOfWork { get; } = unityOfWork;
    }
}