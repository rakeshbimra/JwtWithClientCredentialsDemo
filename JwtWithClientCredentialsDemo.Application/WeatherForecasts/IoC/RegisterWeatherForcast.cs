﻿using JwtWithClientCredentialsDemo.Application.WeatherForecasts.Queries.Handlers;
using JwtWithClientCredentialsDemo.Application.WeatherForecasts.Queries;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JwtWithClientCredentialsDemo.Application.WeatherForecasts.IoC
{
    public static class RegisterWeatherForcast
    {
        public static void AddWeatherForcast(this IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<GetWeatherForecastsQuery, IEnumerable<WeatherForecast>>, GetWeatherForecastsQueryHandler>();
        }
    }
}
