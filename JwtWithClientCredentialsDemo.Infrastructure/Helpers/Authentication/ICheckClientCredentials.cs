using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JwtWithClientCredentialsDemo.Infrastructure.Helpers.Authentication
{
    public interface ICheckClientCredentials
    {
        Task<bool> Validate(string clientId, string clientSecret);
    }
}
