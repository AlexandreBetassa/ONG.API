using Microsoft.EntityFrameworkCore;
using ONG.Person.Api.Domain.Entities.v1.Pet;

namespace ONG.Person.Api.Infrastructure.Data.Context
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Domain.Entities.v1.Persons.Person> Persons { get; set; }
        public DbSet<Pet> Pets { get; set; }
    }
}
