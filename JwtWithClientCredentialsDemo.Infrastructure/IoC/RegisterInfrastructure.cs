using JwtWithClientCredentialsDemo.Application.Authentication;
using JwtWithClientCredentialsDemo.Application.AzureKeyVault;
using JwtWithClientCredentialsDemo.Infrastructure.Authentication;
using JwtWithClientCredentialsDemo.Infrastructure.AzureKeyVault;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JwtWithClientCredentialsDemo.Infrastructure.IoC
{
    public static class RegisterInfrastructure
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();
            services.AddScoped<ICheckClientCredentials, CheckClientCredentials>();
            services.AddScoped<IAzureKeyVaultClient, AzureKeyVaultClient>();
        }
    }
}
