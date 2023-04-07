using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using JwtWithClientCredentialsDemo.Application.Authentication;
using JwtWithClientCredentialsDemo.Application.AzureKeyVault;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JwtWithClientCredentialsDemo.Infrastructure.Authentication
{
    public class CheckClientCredentials : ICheckClientCredentials
    {
        private readonly IAzureKeyVaultClient _azureKeyVaultClient;

        public CheckClientCredentials(IAzureKeyVaultClient azureKeyVaultClient)
        {
            _azureKeyVaultClient = azureKeyVaultClient;
        }

        public async Task<bool> Validate(string clientId, string clientSecret)
        {
            var storedClientId = await _azureKeyVaultClient.GetCachedOrFetchSecretAsync("StoredClientId");

            var storedClientSecret = await _azureKeyVaultClient.GetCachedOrFetchSecretAsync("StoredClientSecret");

            return clientId == storedClientId && clientSecret == storedClientSecret;
        }
    }
}
