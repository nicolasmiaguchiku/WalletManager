using Microsoft.Extensions.DependencyInjection;
using WalletManager.Domain.Interfaces.Repositories;
using WalletManager.Infrastructure.Repositories;

namespace WalletManager.CrossCutting.Extensions
{
    public static class RepositoryExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IWalletRepository, WalletRepository>();
            services.AddScoped<ITransactionRepository, TransactionRepository>();

            return services;
        }
    }
}