using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JwtWithClientCredentialsDemo.Application.ConfigOptions.Validators
{
    public class JwtConfigOptionValidator : AbstractValidator<JwtConfigOption>
    {
        public JwtConfigOptionValidator()
        {
            RuleFor(x => x.Audience).NotEmpty();

            RuleFor(x => x.Issuer).NotEmpty();

            RuleFor(x => x.ExpiryMinutes).NotEmpty();

            RuleFor(x => x.Secret).NotEmpty();
        }
    }
}
