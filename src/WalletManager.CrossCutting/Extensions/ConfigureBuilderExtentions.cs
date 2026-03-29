using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.VisualBasic;
using WalletManager.CrossCutting.Models;

namespace WalletManager.CrossCutting.Extensions
{
    public static class ConfigureBuilderExtentions
    {
        public static Settings GetApplicationSettings(this IConfiguration configuration, IHostEnvironment env)
        {
            var settings = configuration.GetSection("Settings").Get<Settings>()!;

            if (!env.IsDevelopment())
            {
                settings.PostgresSettings.ConnectionString = GetOrDefault("POSTGRES_CONNECTION_STRING", settings.PostgresSettings.ConnectionString);
                settings.JwtSettings.SecretKey = GetOrDefault("Jwt_SecretKey", settings.JwtSettings.SecretKey);
            }

            return settings;
        }

        private static string GetOrDefault(string key, string? fallback)
        {
            var value = Environment.GetEnvironmentVariable(key);
            return string.IsNullOrEmpty(value) ? fallback ?? "" : value;
        }
    }
}