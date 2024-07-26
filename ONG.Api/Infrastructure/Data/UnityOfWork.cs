using ONG.Api.Domain.Interfaces.v1.Repositories;
using ONG.Api.Infrastructure.Data.Context;

namespace ONG.Api.Infrastructure.Data
{
    public class UnityOfWork : IUnityOfWork
    {
        public IPersonRepository<Domain.Entities.v1.Persons.Person> PersonRepository { get; }
        private readonly AppDbContext _ctx;

        public UnityOfWork(AppDbContext ctx,
            IPersonRepository<Domain.Entities.v1.Persons.Person> personRepository)
        {
            _ctx = ctx;
            PersonRepository = personRepository;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _ctx.Dispose();
            }
        }

        public async Task SaveAsync()
        {
            await _ctx.SaveChangesAsync();
        }
    }
}