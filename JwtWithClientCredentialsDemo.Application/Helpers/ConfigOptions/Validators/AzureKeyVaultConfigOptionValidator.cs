﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JwtWithClientCredentialsDemo.Application.ConfigOptions.Validators
{
    public class AzureKeyVaultConfigOptionValidator : AbstractValidator<AzureKeyVaultConfigOption>
    {
        public AzureKeyVaultConfigOptionValidator()
        {
            
        }
    }
}
