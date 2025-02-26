using Maintenance.Api.Extensions;
using Maintenance.Application;
using Maintenance.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddApiServices()
    .AddSwaggerConfiguration()
    .AddApplication()
    .AddInfrastructure(builder.Configuration);

var app = builder.Build();

app.UseApiConfiguration(app.Environment);

app.Run();