namespace ONG.Person.Api.Domain.Interfaces.v1.Repositories
{
    public interface IPersonRepository<T> where T : Entities.v1.Persons.Person
    {
        Task<T> GetByCpf(string cpf);
        Task<T> GetByEmailAsync(string email);
        Task Create(T person);
        Task Update(T person);
    }
}