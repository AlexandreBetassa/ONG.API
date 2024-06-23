using Microsoft.EntityFrameworkCore;

namespace ONG.Person.Api.Infrastructure.Data.Context
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Domain.Entities.v1.Person> Persons { get; set; }
    }
}
