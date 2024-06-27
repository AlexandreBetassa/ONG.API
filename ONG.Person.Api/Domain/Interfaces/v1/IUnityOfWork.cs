using ONG.Person.Api.Domain.Entities.v1.Pet;

namespace ONG.Person.Api.Domain.Interfaces.v1
{
    public interface IUnityOfWork : IDisposable
    {
        IPersonRepository<Entities.v1.Persons.Person> PersonRepository { get; }
        IPetRepository<Pet> PetRepository { get; }

        Task SaveAsync();
    }
}
