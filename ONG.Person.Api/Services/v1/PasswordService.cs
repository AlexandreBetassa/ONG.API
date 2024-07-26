using Microsoft.AspNetCore.Identity;
using ONG.Person.Api.Domain.Interfaces.v1.Services;

namespace ONG.Person.Api.Services.v1
{
    public class PasswordService : IPasswordServices
    {
        private readonly PasswordHasher<Domain.Entities.v1.Persons.Person> _passwordHasher;

        public PasswordService(PasswordHasher<Domain.Entities.v1.Persons.Person> passwordHasher)
        {
            _passwordHasher = passwordHasher;
        }

        public string HashPassword(Domain.Entities.v1.Persons.Person user)
        {
            return _passwordHasher.HashPassword(user, user.Password);
        }
    }
}
