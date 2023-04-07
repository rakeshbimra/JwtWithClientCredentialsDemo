using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JwtWithClientCredentialsDemo.Application.Helpers.Extensions
{
   public static class FluentValidationOptionsExtensions
    {
        public static OptionsBuilder<TOptions> AddWithValidation<TOptions, TValidator>(
            this IServiceCollection services,
            string configurationSection)
        where TOptions : class
        where TValidator : class, IValidator<TOptions>
        {
            services.AddScoped<IValidator<TOptions>, TValidator>();

            return services.AddOptions<TOptions>()
                .BindConfiguration(configurationSection)
                .ValidateFluentValidation();
                //.ValidateOnStart()
        }
    }
}
