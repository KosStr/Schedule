using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Schedule.Core.Configurations;

namespace Schedule.Extensions
{
    public static class SingletonsExtention
    {
        public static void AddSingletons(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtSettings = new JwtSettings();
            configuration.GetSection("JwtSettings").Bind(jwtSettings);
            services.AddSingleton(jwtSettings);

            var emailSettings = new EmailSettings();
            configuration.GetSection("EmailSettings").Bind(emailSettings);
            services.AddSingleton(emailSettings);

            var blobStorageOptions = new AzureBlobStorageOptions();
            configuration.GetSection("AzureBlobStorageOptions").Bind(blobStorageOptions);
            services.AddSingleton(blobStorageOptions);
        }
    }
}
