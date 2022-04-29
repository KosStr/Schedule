using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Schedule.Extensions
{
    public static class SwaggerExtension
    {
        public static void AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ScheduleAPI", Version = "v1" });
            });
        } 
    }
}
