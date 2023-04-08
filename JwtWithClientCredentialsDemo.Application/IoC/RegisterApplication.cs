using JwtWithClientCredentialsDemo.Application.Authentication;
using JwtWithClientCredentialsDemo.Application.ConfigOptions;
using JwtWithClientCredentialsDemo.Application.ConfigOptions.Validators;
using JwtWithClientCredentialsDemo.Application.Helpers.Extensions;
using JwtWithClientCredentialsDemo.Application.WeatherForecasts.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JwtWithClientCredentialsDemo.Application.IoC
{
    public static class RegisterApplication
    {
        public static void AddApplication(this IServiceCollection services)
        {
            //use extenstion method
            services.AddWithValidation<JwtConfigOption, JwtConfigOptionValidator>(JwtConfigOption.SectionName);
            services.AddWithValidation<AzureKeyVaultConfigOption, AzureKeyVaultConfigOptionValidator>(AzureKeyVaultConfigOption.SectionName);
            services.AddWeatherForcast();
        }
    }
}
