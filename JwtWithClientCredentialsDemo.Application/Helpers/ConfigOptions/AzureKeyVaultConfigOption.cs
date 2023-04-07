using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JwtWithClientCredentialsDemo.Application.ConfigOptions
{
    public class AzureKeyVaultConfigOption
    {
        public const string SectionName = nameof(JwtConfigOption);
        public string Url { get; set; }
    }
}
