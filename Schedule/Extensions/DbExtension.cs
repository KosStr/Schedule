using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Schedule.database;

namespace Schedule.Extensions
{
    public static class DbExtension
    {
        public static void AddDatabaseContext(this IServiceCollection services, IConfiguration configuration) =>
            services.AddDbContext<SqlDatabase>(options =>
            {
                options.EnableDetailedErrors(true);
                options.UseSqlServer(configuration.GetConnectionString("ScheduleConnection"));
            });
    }
}
