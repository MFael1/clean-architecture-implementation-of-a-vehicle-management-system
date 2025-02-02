using Motors.Application;
using Motors.Infrastructure;
using Motors.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddApiServices()
    .AddSwaggerConfiguration()
    .AddApplication()
    .AddInfrastructure(builder.Configuration);

var app = builder.Build();

app.UseApiConfiguration(app.Environment);

app.Run();