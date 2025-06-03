using Microsoft.AspNetCore.Http.HttpResults;
using minimal_api.DTOs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapPost("login", (LoginDTO loginDTO) =>
{
    if (loginDTO.Email == "adm@teste.com" && loginDTO.Password == "123456")
    {
        return Results.Ok("Login com sucesso");
    }
    else
    {
        return Results.Unauthorized();
    }
});

app.Run();
