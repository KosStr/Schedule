using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Schedule.Business;
using Schedule.Core.Enums;
using Schedule.Extensions;

namespace Schedule
{
    public class Startup
    {
        public Startup(IWebHostEnvironment environment)
        {
            Environment = environment;

            var builder = new ConfigurationBuilder()
                .SetBasePath(Environment.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{Environment.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            this.Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        private IWebHostEnvironment Environment { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSingletons(Configuration);
            services.AddApplicationCors(Configuration);
            services.AddJwtAuthentication();
            services.AddEmail();
            services.AddDatabaseContext(Configuration);
            services.AddServices(Configuration);
            services.AddSwagger();
            services.AddHttpContextAccessor();
            services.AddLogging();

            services.AddAuthorization(options =>
            {
                options.AddPolicy(nameof(Role.Student), policy => policy.RequireRole(nameof(Role.Student)));
                options.AddPolicy(nameof(Role.Teacher), policy => policy.RequireRole(nameof(Role.Teacher)));
                options.AddPolicy(nameof(Role.Admin), policy => policy.RequireRole(nameof(Role.Admin)));
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
            }

            app.UseMiddlewareHandler();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Schedule-API");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("CorsPolicy");

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule(new BusinessModule());
        }
    }
}