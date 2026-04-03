namespace WalletManager.Application.Responses;

public record WalletResponse(
    Guid CustomerId,
    decimal Balance,
    IEnumerable<TransactionResponse> Transactions);