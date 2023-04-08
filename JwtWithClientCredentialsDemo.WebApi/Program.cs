using JwtWithClientCredentialsDemo.Application.IoC;
using JwtWithClientCredentialsDemo.Infrastructure.IoC;
using JwtWithClientCredentialsDemo.WebApi.IoC;
using Microsoft.AspNetCore.Builder;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });

    });
    builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<Program>());

    builder.Services.AddApplication();
    builder.Services.AddInfrastructure();
    builder.Services.AddWebApi();
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

    // Authentication & Authorization
    app.UseAuthentication();
    app.UseAuthorization();
    app.MapControllers();

   

    
}

if (app.Environment.IsDevelopment())
{
   //DEV configurations
}



app.Run();
