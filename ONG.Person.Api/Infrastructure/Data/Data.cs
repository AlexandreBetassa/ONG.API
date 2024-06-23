using Microsoft.EntityFrameworkCore;
using ONG.Person.Api.Domain.Entities.v1;
using ONG.Person.Api.Domain.Interfaces.v1;
using ONG.Person.Api.Infrastructure.Data.Context;

namespace ONG.Person.Api.Infrastructure.Data
{
    public class Data<T>(AppDbContext ctx) : IData<T> where T : BaseEntity
    {
        public AppDbContext Ctx => ctx;

        public async Task Create(T entity)
        {
            await ctx.Set<T>().AddAsync(entity);

            await ctx.SaveChangesAsync();
        }

        public async Task<T> GetById(Guid id) =>
            await ctx.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
    }
}