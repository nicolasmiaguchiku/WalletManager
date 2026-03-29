using WalletManager.Domain.Base;
using WalletManager.Domain.ValueObjects;

namespace WalletManager.Domain.Interfaces.Services
{
    public interface IAuthenticationService
    {
        Task<Result<Token>> Authenticate(User user);
    }
}
