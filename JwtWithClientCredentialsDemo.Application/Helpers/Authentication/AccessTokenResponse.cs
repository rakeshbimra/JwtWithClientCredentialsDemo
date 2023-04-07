using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JwtWithClientCredentialsDemo.Application.Authentication
{
    public class AccessTokenResponse
    {
        [JsonProperty("access_toknen")]
        public string AccessToken { get; set; }

        [JsonProperty("token_type")]
        public string TokenType { get; } = "Bearer";

        [JsonProperty("expires_in")]
        public long ExpiresIn { get; set; }
    }
}
