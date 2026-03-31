using Microsoft.Extensions.DependencyInjection;
using WalletManager.Domain.Interfaces.Services;
using WalletManager.Infrastructure.Services;

namespace WalletManager.CrossCutting.Extensions
{
    public static class ServicesExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IPasswordHashService, PasswordHashService>();
            return services;
        }
    }
}