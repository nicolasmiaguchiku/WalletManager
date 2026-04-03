namespace WalletManager.Application.Responses;

public record TransactionResponse(
    Guid Id,
    Guid WalletId,
    decimal Amount,
    string Description,
    string Type,
    DateTime CreatedAt);