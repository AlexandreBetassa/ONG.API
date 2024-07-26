using Microsoft.EntityFrameworkCore;

namespace ONG.Api.Infrastructure.Data.Context
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Domain.Entities.v1.Persons.Person> Persons { get; set; }
    }
}
