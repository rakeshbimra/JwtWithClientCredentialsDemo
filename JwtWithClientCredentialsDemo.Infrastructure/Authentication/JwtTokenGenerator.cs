using JwtWithClientCredentialsDemo.Application.Authentication;
using JwtWithClientCredentialsDemo.Application.ConfigOptions;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace JwtWithClientCredentialsDemo.Infrastructure.Authentication
{
    public class JwtTokenGenerator : IJwtTokenGenerator
    {
        private readonly JwtConfigOption _jwtConfigOption;
        private readonly ICheckClientCredentials _checkClientCredentials;

        public JwtTokenGenerator(IOptions<JwtConfigOption> jwtSetings,
            ICheckClientCredentials checkClientCredentials)
        {
            _jwtConfigOption = jwtSetings.Value;
            _checkClientCredentials = checkClientCredentials;
        }

        public async Task<AccessTokenResponse> GenerateToken(string clientId, string clientSecret)
        {
            //if (!await _checkClientCredentials.Validate(clientId, clientSecret))
            //{
            //    throw new UnauthorizedAccessException("Invalid client credentails");
            //}

            var signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(_jwtConfigOption.Secret)),
                    SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim("client_id",clientId),
                new Claim (JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
            };

            var securityToken = new JwtSecurityToken(
                issuer: _jwtConfigOption.Issuer,
                audience: _jwtConfigOption.Audience,
                expires: DateTime.Now.AddMinutes(_jwtConfigOption.ExpiryMinutes),
                claims: claims,
                signingCredentials: signingCredentials);

            return new AccessTokenResponse
            {
                AccessToken = new JwtSecurityTokenHandler().WriteToken(securityToken),
                ExpiresIn = securityToken.ValidTo.Ticks
            };
        }
    }
}
