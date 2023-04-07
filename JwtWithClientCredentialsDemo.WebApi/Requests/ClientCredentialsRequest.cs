using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JwtWithClientCredentialsDemo.WebApi.Requests
{
    public class ClientCredentialsRequest
    {
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
    }
}
