namespace WalletManager.Application.Responses;

public record GetTransactionResponse(
    Guid Id,
    Guid WalletId,
    decimal Amount,
    string Description,
    string Type,
    DateTime CreatedAt);