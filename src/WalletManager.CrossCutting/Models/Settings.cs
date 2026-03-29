using WalletManager.Infrastructure.Models;

namespace WalletManager.CrossCutting.Models
{
    public interface ISettings
    {
        public PostgresSettings PostgresSettings { get; }
        public JwtSettings JwtSettings { get; }
    }

    public class Settings : ISettings
    {
        public required PostgresSettings PostgresSettings { get; set; }
        public required JwtSettings JwtSettings { get; set; }
    }
}