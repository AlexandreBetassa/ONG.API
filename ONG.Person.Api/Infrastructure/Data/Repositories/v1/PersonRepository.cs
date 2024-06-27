using Microsoft.EntityFrameworkCore;
using ONG.Person.Api.Domain.Interfaces.v1;

namespace ONG.Person.Api.Infrastructure.Data.Repositories.v1
{
    public class PersonRepository<T>(IData<Domain.Entities.v1.Person> data) : IPersonRepository<Domain.Entities.v1.Person>
    {
        private readonly IData<Domain.Entities.v1.Person> _data = data;

        public async Task Create(Domain.Entities.v1.Person person) =>
            await _data.Create(person);

        public async Task<Domain.Entities.v1.Person> GetByCpf(string cpf) =>
            await _data.Ctx.Set<Domain.Entities.v1.Person>()
            .AsNoTracking()
            .Include(a => a.Address)
            .Include(c => c.Contact)
            .FirstOrDefaultAsync(person => person.Cpf == cpf);

        public async Task Update(Domain.Entities.v1.Person person)
        {
            await _data.Update(person);
        }
    }
}