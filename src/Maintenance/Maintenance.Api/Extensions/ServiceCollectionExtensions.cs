using System.Text.Json.Serialization;
using Maintenance.Api.Middlewares;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;

namespace Maintenance.Api.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApiServices(this IServiceCollection services)
    {
        // Add controllers with JSON options
        services.AddControllers()
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            });
        
        
        services.AddRouting();
    
        services.AddEndpointsApiExplorer();

        services.AddProblemDetails();

        services.AddExceptionHandler<GlobalExceptionHandler>();
        
        // Configure API behavior
        services.Configure<ApiBehaviorOptions>(options =>
        {
            options.SuppressModelStateInvalidFilter = true;
        });

        return services;
    }

    public static IServiceCollection AddSwaggerConfiguration(this IServiceCollection services)
    {
        services.AddSwaggerGen(options =>
        {
            // Configure DateOnly and TimeSpan types for Swagger
            options.MapType<DateOnly>(() => new OpenApiSchema
            {
                Type = "string",
                Format = "date"
            });
            
            options.MapType<TimeSpan>(() => new OpenApiSchema
            {
                Type = "string",
                Format = "duration",
                Example = new OpenApiString("02:00:00")
            });
        });

        return services;
    }
}