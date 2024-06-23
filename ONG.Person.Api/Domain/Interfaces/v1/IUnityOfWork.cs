namespace ONG.Person.Api.Domain.Interfaces.v1
{
    public interface IUnityOfWork : IDisposable
    {
        IPersonRepository<Entities.v1.Person> PersonRepository { get; }

        Task SaveAsync();
    }
}
