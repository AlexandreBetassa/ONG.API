namespace ONG.Api.Domain.Interfaces.v1.Configurations.v1
{
    public interface IJwtConfiguration
    {
        public string SecretJwtKey { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public int ExpirationInMinutes { get; set; }
        public string[] WriteRoles { get; set; }
        public string[] ReadRoles { get; set; }
    }
}