using Microsoft.EntityFrameworkCore;
using ONG.Api.Domain.Interfaces.v1.Repositories;

namespace ONG.Api.Infrastructure.Data.Repositories.v1
{
    public class PersonRepository<T>(IData<Domain.Entities.v1.Persons.Person> data) : IPersonRepository<Domain.Entities.v1.Persons.Person>
    {
        private readonly IData<Domain.Entities.v1.Persons.Person> _data = data;

        public async Task Create(Domain.Entities.v1.Persons.Person person) =>
            await _data.Create(person);

        public async Task<Domain.Entities.v1.Persons.Person> GetByCpf(string cpf) =>
            await _data.Ctx.Set<Domain.Entities.v1.Persons.Person>()
            .AsNoTracking()
            .Include(a => a.Address)
            .Include(c => c.Contact)
            .FirstOrDefaultAsync(person => person.Cpf == cpf);

        public async Task<Domain.Entities.v1.Persons.Person> GetByEmailAsync(string email)
        {
            return await _data.Ctx.Set<Domain.Entities.v1.Persons.Person>()
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task Update(Domain.Entities.v1.Persons.Person person)
        {
            await _data.Update(person);
        }
    }
}