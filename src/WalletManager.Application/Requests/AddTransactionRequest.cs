using WalletManager.Domain.Enum;

namespace WalletManager.Application.Requests;

public record AddTransactionRequest(
    decimal Amount,
    string? Description,
    TransactionType Type);