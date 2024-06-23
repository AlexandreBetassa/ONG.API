using ONG.Person.Api.Domain.Interfaces.v1;
using ONG.Person.Api.Infrastructure.Data.Context;

namespace ONG.Person.Api.Infrastructure.Data
{
    public class UnityOfWork : IUnityOfWork
    {
        public IPersonRepository<Domain.Entities.v1.Person> PersonRepository { get; }
        private readonly AppDbContext _ctx;

        public UnityOfWork(AppDbContext ctx,
            IPersonRepository<Domain.Entities.v1.Person> personRepository)
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
