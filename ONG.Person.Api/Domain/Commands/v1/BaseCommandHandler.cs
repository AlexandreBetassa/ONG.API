using AutoMapper;
using ONG.Person.Api.Domain.Interfaces.v1;

namespace ONG.Person.Api.Domain.Commands.v1
{
    public abstract class BaseCommandhandler(IMapper mapper, IUnityOfWork unityOfWork)
    {
        public ILogger Logger { get; set; }
        public IMapper Mapper { get; } = mapper;
        public IUnityOfWork UnityOfWork { get; } = unityOfWork;
    }
}