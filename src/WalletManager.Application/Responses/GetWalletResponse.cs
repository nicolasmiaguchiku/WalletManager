namespace WalletManager.Application.Responses;

public record GetWalletResponse(
    Guid CustomerId,
    decimal Balance,
    IEnumerable<GetTransactionResponse> Transactions);