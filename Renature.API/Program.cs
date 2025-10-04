using Renature.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.UseApiServices();

var app = builder.Build();

app.UseApiMiddlewares();

app.MapGet("/", () => "Hello World!");

app.Run();