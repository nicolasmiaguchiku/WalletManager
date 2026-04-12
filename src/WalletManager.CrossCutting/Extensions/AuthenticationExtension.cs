using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using WalletManager.Infrastructure.Models;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Options;

namespace WalletManager.CrossCutting.Extensions
{
    public static class AuthenticationExtension
    {
        public static IServiceCollection ConfigureAuthentication(this IServiceCollection services, JwtSettings jwtSettings)
        {
            services.AddJwtSettings(jwtSettings);

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ClockSkew = TimeSpan.Zero,
                    ValidAudience = jwtSettings.Audience,
                    ValidIssuer = jwtSettings.Issuer,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SecretKey))
                };
            });

            return services;
        }

        private static IServiceCollection AddJwtSettings(this IServiceCollection services, JwtSettings jwtSettings)
        {
            services.AddSingleton<IOptions<JwtSettings>>(Options.Create(jwtSettings));
            return services;
        }
    }
}