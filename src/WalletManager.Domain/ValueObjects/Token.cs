namespace WalletManager.Domain.ValueObjects
{
    public record Token(
    string AccessToken,
    string RefreshToken,
    DateTime RefreshTokenExpiresAt);
}