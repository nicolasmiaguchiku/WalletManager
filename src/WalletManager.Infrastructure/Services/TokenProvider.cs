using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using WalletManager.Domain.Interfaces.Services;
using WalletManager.Infrastructure.Models;

namespace WalletManager.Infrastructure.Services
{
    public class TokenProvider(IOptions<JwtSettings> settings) : ITokenProvider
    {
        private readonly JwtSecurityTokenHandler _tokenHandler = new();

        public JwtSecurityToken GenerateAccessToken(IEnumerable<Claim> claims)
        {
            var key = settings.Value.SecretKey;

            var privateKey = Encoding.UTF8.GetBytes(key);

            var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(privateKey),
                                            SecurityAlgorithms.HmacSha256Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(settings.Value.TokenValidityInMinutes),
                Audience = settings.Value.Audience,
                Issuer = settings.Value.Issuer,
                SigningCredentials = signingCredentials
            };

            var token = _tokenHandler.CreateJwtSecurityToken(tokenDescriptor);

            return token;
        }

        public string GenerateRefreshToken()
        {
            var secureRandomBytes = new byte[128];

            using var randomNumberGenerator = RandomNumberGenerator.Create();

            randomNumberGenerator.GetBytes(secureRandomBytes);

            var refreshToken = Convert.ToBase64String(secureRandomBytes);

            return refreshToken;
        }
    }
}