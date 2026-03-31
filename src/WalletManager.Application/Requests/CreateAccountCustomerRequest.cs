namespace WalletManager.Application.Requests;

public record CreateAccountCustomerRequest(
    string Name,
    string Email,
    string PhoneNumber,
    string Password,
    string ConfirmPassword);