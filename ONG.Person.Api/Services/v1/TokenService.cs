using Microsoft.IdentityModel.Tokens;
using ONG.Person.Api.Domain.Interfaces.v1.Configurations.v1;
using ONG.Person.Api.Domain.Interfaces.v1.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ONG.Person.Api.Services.v1
{
    public class TokenService : ITokenService
    {
        private readonly IJwtConfiguration _jwtConfigurations;

        public TokenService(IJwtConfiguration jwtConfigurations)
        {
            _jwtConfigurations = jwtConfigurations;
        }

        public string GenerateToken(Domain.Entities.v1.Persons.Person user)
        {
            var handler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(_jwtConfigurations.SecretJwtKey);
            var credentials = new SigningCredentials(
                                                    new SymmetricSecurityKey(key),
                                                    SecurityAlgorithms.HmacSha256Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = _jwtConfigurations.Issuer,
                Audience = _jwtConfigurations.Audience,
                Subject = GenerateClaims(user),
                Expires = DateTime.UtcNow.AddMinutes(_jwtConfigurations.ExpirationInMinutes),
                SigningCredentials = credentials,
            };

            var token = handler.CreateToken(tokenDescriptor);
            return handler.WriteToken(token);
        }

        private ClaimsIdentity GenerateClaims(Domain.Entities.v1.Persons.Person user)
        {
            var ci = new ClaimsIdentity();
            ci.AddClaim(new Claim(ClaimTypes.Name, user.Name));
            ci.AddClaim(new Claim(ClaimTypes.Email, user.Email));

            foreach (var role in user.Roles)
                ci.AddClaim(new Claim(ClaimTypes.Role, role));

            return ci;
        }
    }
}
