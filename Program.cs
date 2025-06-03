using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using minimal_api.Domain.Services;
using minimal_api.DTOs;
using minimal_api.Infra.Db;
using minimal_api.Infra.Interfaces;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddScoped<iAdministratorService, AdministratorService>();
builder.Services.AddOpenApi();
builder.Services.AddDbContext<DatabaseContext>( options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
}
);   

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapPost("login", ([FromBody] LoginDTO loginDTO, iAdministratorService administratorService) =>
{
    if (administratorService.login(loginDTO) != null)
    {
        return Results.Ok("Login com sucesso");
    }
    else
    {
        return Results.Unauthorized();
    }
});

app.Run();
