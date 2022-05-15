using Microsoft.AspNetCore.Builder;
using Schedule.Middleware;

namespace Schedule.Extensions
{
    public static class MiddlewareHandlerExtension
    {
        public static IApplicationBuilder UseMiddlewareHandler(this IApplicationBuilder builder) =>
            builder.UseMiddleware<ExceptionMiddleware>();

        public static IApplicationBuilder UseRefreshTokenHandler(this IApplicationBuilder builder) =>
            builder.UseMiddleware<RefreshTokenMiddleware>();
    }
}
