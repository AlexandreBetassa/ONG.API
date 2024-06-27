using ONG.Person.Api.Domain.Entities.v1.Pet;

namespace ONG.Person.Api.Domain.Interfaces.v1
{
    public interface IPetRepository<T> where T : Pet
    {
        Task Create(T pet);
    }
}