using LiteBus.Messaging.Extensions.MicrosoftDependencyInjection;
using LiteBus.Commands.Extensions.MicrosoftDependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using WalletManager.Application.UseCases.Commands.Customer;
using LiteBus.Queries.Extensions.MicrosoftDependencyInjection;
using WalletManager.Application.UseCases.Queries.Wallet;

namespace WalletManager.CrossCutting.Extensions
{
    public static class MediatorExtensions
    {
        public static IServiceCollection AddMediator(this IServiceCollection services)
        {
            services.AddLiteBus(litebus =>
            {
                litebus.AddCommandModule(module =>
                {
                    module.RegisterFromAssembly(typeof(CreateAccountCustomerCommand).Assembly);
                });

                litebus.AddQueryModule(module =>
                {
                    module.RegisterFromAssembly(typeof(GetWalletQuery).Assembly);
                });

            });

            return services;
        }
    }
}