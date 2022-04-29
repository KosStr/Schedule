using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Schedule.Business;
using Schedule.Extensions;
using System;

namespace Schedule
{
    public class Startup
    {
        public Startup(ILogger<Startup> logger, IWebHostEnvironment environment)
        {
            Environment = environment;

            var builder = new ConfigurationBuilder()
                .SetBasePath(Environment.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{Environment.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            this.Configuration = builder.Build();
            this.logger = logger;
        }

        public IConfiguration Configuration { get; }

        private IWebHostEnvironment Environment { get; }

        private readonly ILogger logger;

        public void ConfigureServices(IServiceCollection services, IServiceProvider serviceProvider)
        {
            services.AddControllers();
            services.AddSingletons(Configuration);
            services.AddApplicationCors(Configuration);
            services.AddJwtAuthentication(serviceProvider);
            services.AddEmail(serviceProvider);
            services.AddDatabaseContext(Configuration);
            services.AddSwagger();
            services.AddHttpContextAccessor();
            services.AddLogging();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                logger.LogInformation("Configuring for Development environment");
                app.UseDeveloperExceptionPage();
            }
            else
            {
                logger.LogInformation("Configuring for Production environment");
            }

            app.UseMiddlewareHandler();

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