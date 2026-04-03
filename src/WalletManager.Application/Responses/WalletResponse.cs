namespace WalletManager.Application.Responses;

public record WalletResponse(decimal Balance, IEnumerable<TransactionResponse> Transactions);