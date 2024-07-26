using ONG.Api.Infrastructure.Data.Context;

namespace ONG.Api.Domain.Interfaces.v1.Repositories
{
    public interface IData<T> where T : class
    {
        public AppDbContext Ctx { get; }
        Task Update(T entity);
        Task Create(T entity);
        Task<T> GetById(string id);
    }
}
