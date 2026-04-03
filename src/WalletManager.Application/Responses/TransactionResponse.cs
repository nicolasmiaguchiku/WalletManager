namespace WalletManager.Application.Responses;

public record TransactionResponse(
    Guid Id,
    decimal Amount,
    string Description,
    string Type,
    DateTime CreatedAt);