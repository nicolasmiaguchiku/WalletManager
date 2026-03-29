namespace WalletManager.Domain.Interfaces.Services
{
    public interface IPasswordHashService
    {
        bool ComparePassword(string password, string confirmPasswordHash);
        string EncryptPassword(string password);
        bool VerifyPassword(string password, string passwordHash);
    }
}