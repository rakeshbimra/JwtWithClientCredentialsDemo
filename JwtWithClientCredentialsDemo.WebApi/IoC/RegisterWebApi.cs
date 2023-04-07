using JwtWithClientCredentialsDemo.Application.Helpers.Extensions;
using JwtWithClientCredentialsDemo.WebApi.Requests;
using JwtWithClientCredentialsDemo.WebApi.Requests.Validators;

namespace JwtWithClientCredentialsDemo.WebApi.IoC
{
    public static class RegisterWebApi
    {
        public static void AddWebApi(this IServiceCollection services)
        {
            services.AddWithValidation<ClientCredentialsRequest, ClientCredentialsRequestValidator>(ClientCredentialsRequest.SectionName);
        }
    }
}
