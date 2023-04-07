using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JwtWithClientCredentialsDemo.Application.AzureKeyVault
{
    public interface IAzureKeyVaultClient
    {
        Task<string> GetSecretAsync(string secretName);
        Task<string> GetCachedOrFetchSecretAsync(string secretName);
    }
}
