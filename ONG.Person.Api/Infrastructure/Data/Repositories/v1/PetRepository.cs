using ONG.Person.Api.Domain.Entities.v1.Pet;
using ONG.Person.Api.Domain.Interfaces.v1;

namespace ONG.Person.Api.Infrastructure.Data.Repositories.v1
{
    public class PetRepository<T>(IData<T> data) : IPetRepository<T> where T : Pet
    {
        private readonly IData<T> _data = data;

        public async Task Create(T pet)
        {
            await _data.Create(pet);
        }
    }
}