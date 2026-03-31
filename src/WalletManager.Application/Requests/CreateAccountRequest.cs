namespace WalletManager.Application.Requests;

public record CreateAccountRequest(
    string Name,
    string Email,
    string PhoneNumber,
    string Password,
    string ConfirmPassword);