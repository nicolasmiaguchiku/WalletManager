using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using WalletManager.Domain.Base;
using WalletManager.Domain.Errors;
using WalletManager.Domain.Interfaces.Repositories;
using WalletManager.Domain.Interfaces.Services;
using WalletManager.Domain.ValueObjects;
using WalletManager.Infrastructure.Context;

namespace WalletManager.Infrastructure.Services
{
    public class AuthenticationService(
        IPasswordHashService passwordHashService,
        ICustomerRepository customerRepository,
        ITokenProvider tokenProvider) : IAuthenticationService
    {
        private readonly JwtSecurityTokenHandler _tokenHandler = new();

        public async Task<Result<Token>> Authenticate(User user, CancellationToken cancellationToken)
        {
            var customer = await customerRepository.GetAsync(x => x.Email == user.Email, cancellationToken);

            if (customer is null || !passwordHashService.VerifyPassword(user.Password, customer.PasswordHash))
            {
                return Result<Token>.Failure(CustomerErrors.EmailOrPasswordError);
            }

            var claims = new List<Claim>()
            {
                new (ClaimTypes.NameIdentifier, customer.Id.ToString()),
                new (ClaimTypes.Email, customer.Email),
                new (ClaimTypes.Name, customer.Name)
            };

            var accessToken = tokenProvider.GenerateAccessToken(claims);

            var refreshToken = tokenProvider.GenerateRefreshToken();

            var token = new Token(_tokenHandler.WriteToken(accessToken), refreshToken);

            return Result<Token>.Success(token);
        }
    }
}
