using WalletManager.Domain.Base;

namespace WalletManager.Domain.Errors
{
    public static class CustomerErrors
    {
        public static Error EmailOrPasswordError = new(
            "CustomerError.EmailOrPasswordError",
            "The email address or password you provided is invalid.");
    }
}