namespace ONG.Api.Domain.Interfaces.v1.Services
{
    public interface IPasswordServices
    {
        public string HashPassword(Entities.v1.Persons.Person user);
        public bool VerifyPassword(Entities.v1.Persons.Person user, string password);
    }
}
