using WalletManager.Domain.Base;

namespace WalletManager.Domain.Errors
{
    public static class CustomerErrors
    {
        public static Error EmailOrPasswordError => new(
            "CustomerError.EmailOrPasswordError",
            "The email address or password you provided is invalid.");

        public static Error EmailAlreadyRegisteredError => new(
            "CustomerError.EmailAlreadyRegistered",
            "The email address is already registered.");

        public static Error PasswordsDoNotMatchError => new(
           "CustomerError.PasswordsDoNotMatchError",
           "The password confirmation does not match the password provided.");
    }
}