using LiteBus.Messaging.Extensions.MicrosoftDependencyInjection;
using LiteBus.Commands.Extensions.MicrosoftDependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using WalletManager.Application.UseCases.Commands.Customer;

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

            });

            return services;
        }
    }
}