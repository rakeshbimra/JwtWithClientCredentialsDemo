using Azure.Core;
using Azure.Security.KeyVault.Secrets;
using JwtWithClientCredentialsDemo.Application.AzureKeyVault;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JwtWithClientCredentialsDemo.Infrastructure.AzureKeyVault
{
    public class AzureKeyVaultClient : IAzureKeyVaultClient
    {
        private readonly SecretClient _secretClient;
        private static readonly Dictionary<string, string> _secretCache = new Dictionary<string, string>();

        public AzureKeyVaultClient(string keyVaultUri, TokenCredential tokenCredentail)
        {
            _secretClient = new SecretClient(new Uri(keyVaultUri), tokenCredentail);
        }

        public async Task<string> GetCachedOrFetchSecretAsync(string secretName)
        {
            if (_secretCache.TryGetValue(secretName, out var secretValue))
            {
                return secretValue;
            }

            return await GetSecretAsync(secretName);
        }

        public async Task<string> GetSecretAsync(string secretName)
        {
            if (_secretCache.TryGetValue(secretName, out var secretValue))
            {
                return secretValue;
            }

            var secret = await _secretClient.GetSecretAsync(secretName);
            _secretCache[secretName] = secret.Value.Value;
            return secret.Value.Value;
        }
    }
}
