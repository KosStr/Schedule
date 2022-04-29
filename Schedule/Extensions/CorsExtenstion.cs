using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Schedule.Extensions
{
    public static class CorsExtenstion
    {
        public static void AddApplicationCors(this IServiceCollection services, IConfiguration configuration) =>
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                {
                    builder
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials()
                    .WithOrigins(configuration["Client:BaseUrl"]);
                });
            });
    }
}
