using FluentValidation;
using JwtWithClientCredentialsDemo.Application.Authentication;
using JwtWithClientCredentialsDemo.Common.Responses;
using JwtWithClientCredentialsDemo.WebApi.Requests;
using JwtWithClientCredentialsDemo.WebApi.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Net;

namespace JwtWithClientCredentialsDemo.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccessTokenController : ControllerBase
    {
        private readonly ILogger<AccessTokenController> _logger;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IValidator<ClientCredentialsRequest> _clientCredentialsRequestValidator;
        public AccessTokenController(ILogger<AccessTokenController> logger,
            IJwtTokenGenerator jwtTokenGenerator,
            IValidator<ClientCredentialsRequest> clientCredentialsRequestValidator)
        {
            _logger = logger;
            _jwtTokenGenerator = jwtTokenGenerator;
            _clientCredentialsRequestValidator = clientCredentialsRequestValidator;
        }

        [HttpPost]
        [Route("generate")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Generate([FromBody] ClientCredentialsRequest request)
        {
            try
            {
                var validationResult = _clientCredentialsRequestValidator.Validate(request);

                if (!validationResult.IsValid)
                {
                    return new BadRequestResponse
                    {
                        Errors = validationResult.Errors
                                .GroupBy(e => e.PropertyName)
                                .ToDictionary(g => g.Key, g => g.Select(e => e.ErrorMessage).ToList())
                    };
                }

                var accessTokenResponse = await _jwtTokenGenerator.GenerateToken(request.ClientId, request.ClientSecret);
                return Ok(accessTokenResponse);
            }

            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(ex.Message);
            }

            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
