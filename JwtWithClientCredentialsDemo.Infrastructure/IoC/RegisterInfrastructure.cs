using Azure.Identity;
using JwtWithClientCredentialsDemo.Application.Authentication;
using JwtWithClientCredentialsDemo.Application.ConfigOptions;
using JwtWithClientCredentialsDemo.Application.Helpers.AzureKeyVault;
using JwtWithClientCredentialsDemo.Infrastructure.Helpers.Authentication;
using JwtWithClientCredentialsDemo.Infrastructure.Helpers.AzureKeyVault;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace JwtWithClientCredentialsDemo.Infrastructure.IoC
{
    public static class RegisterInfrastructure
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {
            // Register the TokenCredential instance
            services.AddSingleton(provider =>
            {
                // Replace this with your own implementation of TokenCredential
                return new DefaultAzureCredential();
            });

            services.AddTransient<IJwtTokenGenerator, JwtTokenGenerator>();
            services.AddTransient<ICheckClientCredentials, CheckClientCredentials>();

            services.AddSingleton<IKeyVaultClient>(provider =>
            {
                var configOptions = provider.GetRequiredService<IOptions<AzureKeyVaultConfigOption>>();
                var tokenCredential = new DefaultAzureCredential();
                return new KeyVaultClient(tokenCredential, configOptions);
            });

            // Adding Authentication
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = "JwtWithClientCredentialsDemo",
                    ValidAudience = "JwtWithClientCredentialsDemo",
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("super-secret-key")),
                    ClockSkew = TimeSpan.Zero // token should expired after expiry time
                };
            });
        }
    }
}
