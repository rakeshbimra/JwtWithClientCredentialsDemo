using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JwtWithClientCredentialsDemo.Application.ConfigOptions
{
    public class JwtConfigOption
    {
        public const string SectionName = nameof(JwtConfigOption);
        public string Secret { get; init; }
        public string Issuer { get; init; }
        public string Audience { get; init; }
        public int ExpiryMinutes { get; init; }
    }
}
