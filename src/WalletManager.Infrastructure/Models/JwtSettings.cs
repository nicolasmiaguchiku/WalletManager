namespace WalletManager.Infrastructure.Models
{
    public class JwtSettings
    {
        public string SecretKey { get; set; } = default!;
        public double TokenValidityInMinutes { get; set; }
        public string Issuer { get; set; } = default!;
        public string Audience { get; set; } = default!;
    }
}