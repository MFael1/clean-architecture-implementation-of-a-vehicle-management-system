// Motors.Api/Extensions/MiddlewareExtensions.cs

using Motors.Api.Middlewares;

namespace Motors.Api.Extensions;

public static class MiddlewareExtensions
{
    public static IApplicationBuilder UseExceptionHandling(
        this IApplicationBuilder app)
    {
        return app.UseMiddleware<GlobalExceptionHandler>();
    }
}