using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JwtWithClientCredentialsDemo.Common.Requests.Validators
{
    public class ClientCredentialsRequestValidator : AbstractValidator<ClientCredentialsRequest>
    {
        public ClientCredentialsRequestValidator()
        {
            RuleFor(x => x.ClientId).NotEmpty();

            RuleFor(x => x.ClientSecret).NotEmpty();
        }
    }
}
