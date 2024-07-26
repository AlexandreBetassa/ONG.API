using Microsoft.EntityFrameworkCore;
using ONG.Api.Domain.Entities.v1;
using ONG.Api.Domain.Interfaces.v1.Repositories;
using ONG.Api.Infrastructure.Data.Context;

namespace ONG.Api.Infrastructure.Data
{
    public class Data<T>(AppDbContext ctx) : IData<T> where T : BaseEntity
    {
        public AppDbContext Ctx => ctx;

        public async Task Create(T entity)
        {
            await ctx.Set<T>().AddAsync(entity);

            await ctx.SaveChangesAsync();
        }

        public async Task<T> GetById(string id) =>
            await ctx.Set<T>()
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id.ToString() == id);

        public async Task Update(T entity)
        {
            ctx.Set<T>().Update(entity);

            await ctx.SaveChangesAsync();
        }
    }
}