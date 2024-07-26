namespace ONG.Person.Api.Domain.Interfaces.v1.Repositories
{
    public interface IUnityOfWork : IDisposable
    {
        IPersonRepository<Entities.v1.Persons.Person> PersonRepository { get; }

        Task SaveAsync();
    }
}
