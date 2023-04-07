using JwtWithClientCredentialsDemo.Application.IoC;
using JwtWithClientCredentialsDemo.Infrastructure.IoC;
using Microsoft.AspNetCore.Builder;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });

    });

    builder.Services.AddApplication();
    builder.Services.AddInfrastructure();
    builder.Services.AddControllers();
}

var app = builder.Build();
{
    // Enable Swagger
    app.UseSwagger();

    // Enable Swagger UI
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API v1");
        //c.RoutePrefix = "swagger";
        c.RoutePrefix = string.Empty; // Set the RoutePrefix to an empty string
    });
    app.UseHttpsRedirection();
    app.MapControllers();

    // Authentication & Authorization
    app.UseAuthentication();
    app.UseAuthorization();

    
}

if (app.Environment.IsDevelopment())
{
   
}



app.Run();
