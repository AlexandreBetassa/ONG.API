﻿using Microsoft.EntityFrameworkCore;
using ONG.Person.Api.Domain.Entities.v1;
using ONG.Person.Api.Domain.Interfaces.v1.Repositories;
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