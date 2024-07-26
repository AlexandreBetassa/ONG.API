namespace ONG.Person.Api.Domain.Interfaces.v1.Services
{
    public interface ITokenService
    {
        string GenerateToken(Entities.v1.Persons.Person user);
    }
}
