using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using JwtWithClientCredentialsDemo.Application.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JwtWithClientCredentialsDemo.Infrastructure.Authentication
{
    public class AzureKeyVaultClientCredentialsProvider : IAzureKeyVaultClientCredentialsProvider
    {
        public AzureKeyVaultClientCredentialsProvider(string clientIdKey, string clientSecretKey)
        {
           
        }

        public ClientCredentials GetClientCredentials(string clientId)
        {
           
        }
    }
}
