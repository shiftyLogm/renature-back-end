using Renature.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.UseApiServices(builder.Configuration);

var app = builder.Build();

app.UseApiMiddlewares();

app.Run();