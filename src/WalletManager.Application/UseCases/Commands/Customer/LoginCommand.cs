using LiteBus.Commands.Abstractions;
using WalletManager.Application.Requests;
using WalletManager.Domain.Base;
using WalletManager.Domain.ValueObjects;

namespace WalletManager.Application.UseCases.Commands.Customer;

public record LoginCommand(LoginRequest Request) : ICommand<Result<Token>>;