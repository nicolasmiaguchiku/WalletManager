using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WalletManager.CrossCutting.Models;
using WalletManager.Infrastructure.Context;

namespace WalletManager.CrossCutting.Extensions
{
    public static class DatabaseExtensions
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, PostgresSettings postgresSettings)
        {
            services.AddDbContext<DataContext>(config =>
            {
                config.UseNpgsql(postgresSettings.ConnectionString);
                config.EnableSensitiveDataLogging();
            });

            return services;
        }
    }
}