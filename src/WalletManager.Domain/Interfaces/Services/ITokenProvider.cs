using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace WalletManager.Domain.Interfaces.Services
{
    public interface ITokenProvider
    {
        JwtSecurityToken GenerateAccessToken(IEnumerable<Claim> claims);
    }
}