using JwtWithClientCredentialsDemo.Application.WeatherForecasts.Queries;
using JwtWithClientCredentialsDemo.WebApi.Responses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JwtWithClientCredentialsDemo.WebApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IMediator _mediator;

        public WeatherForecastController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize]
        [HttpGet]
        [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task<IActionResult> Get()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                var result = await _mediator.Send(new GetWeatherForecastsQuery());

                return new SuccessResponse<IEnumerable<WeatherForecast>>()
                {
                    Data = result,
                };
            }
            else
            {
                return new UnauthorizedResponse();
            }

            
        }
    }
}
