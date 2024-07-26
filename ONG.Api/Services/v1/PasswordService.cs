using Microsoft.AspNetCore.Identity;
using ONG.Api.Domain.Interfaces.v1.Services;

namespace ONG.Api.Services.v1
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

        public bool VerifyPassword(Domain.Entities.v1.Persons.Person user, string password)
        {
            var result = _passwordHasher.VerifyHashedPassword(user, user.Password, password);

            return result == PasswordVerificationResult.Success;
        }
    }
}
