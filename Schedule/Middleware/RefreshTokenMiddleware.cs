using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Schedule.Core.DTO.Token;
using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using static Schedule.Core.Helpers.Constants;

namespace Schedule.Middleware
{
    public class RefreshTokenMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger<ExceptionMiddleware> logger;

        public RefreshTokenMiddleware(
            RequestDelegate next,
            ILogger<ExceptionMiddleware> logger)
        {
            this.next = next;
            this.logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            if (httpContext.Request.Path.StartsWithSegments(new PathString("/refresh")) &&
                httpContext.Request.Method.Equals("post", StringComparison.OrdinalIgnoreCase))
            {
                logger.LogInformation("Trying to expand refresh model from Http Body");

                using var stream = new StreamReader(httpContext.Request.Body);
                var model = await stream.ReadToEndAsync();
                var tokenUpdateModel = JsonSerializer.Deserialize<TokenUpdateDto>(model);

                logger.LogInformation("Trying to insert refresh token from cookies to Http Body");

                tokenUpdateModel.RefreshToken = httpContext.Request.Cookies[Cookies.RefreshTokenKey];

                using var ms = new MemoryStream();
                using var sw = new StreamWriter(ms);
                await sw.WriteAsync(JsonSerializer.Serialize(tokenUpdateModel));
                httpContext.Request.Body = ms;

                logger.LogInformation("Expanding and inserting refresh token from cookies have been finished successfully.");
            }

            await next(httpContext);
        }
    }
}
