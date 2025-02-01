using System.Net;
using System.Text.Json;
using FluentValidation;

namespace Motors.Api.Middlewares;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;

    public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception error)
        {
            var response = context.Response;
            response.ContentType = "application/json";
            
            response.StatusCode = error switch
            {
                ValidationException => (int)HttpStatusCode.BadRequest,
                ApplicationException => (int)HttpStatusCode.BadRequest,
                KeyNotFoundException => (int)HttpStatusCode.NotFound,
                _ => (int)HttpStatusCode.InternalServerError
            };

            var result = JsonSerializer.Serialize(new
            {
                StatusCode = response.StatusCode,
                Message = error.Message
            });

            _logger.LogError(error, error.Message);
            await response.WriteAsync(result);
        }
    }
}