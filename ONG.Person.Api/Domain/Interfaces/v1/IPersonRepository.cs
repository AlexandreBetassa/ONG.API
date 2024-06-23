namespace ONG.Person.Api.Domain.Interfaces.v1
{
    public interface IPersonRepository<T> where T : Entities.v1.Person
    {
        Task<T> GetByCpf(string cpf);
        Task Create(T person);
    }
}