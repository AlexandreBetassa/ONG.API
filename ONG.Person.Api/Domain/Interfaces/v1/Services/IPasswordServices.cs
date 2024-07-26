namespace ONG.Person.Api.Domain.Interfaces.v1.Services
{
    public interface IPasswordServices
    {
        public string HashPassword(Entities.v1.Persons.Person user);
    }
}
