using Azure.Storage.Blobs;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Schedule.Extensions
{
    public static class ServicesExtension
    {
        public static void AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(_ => new BlobServiceClient(configuration["AzureBlobStorageOptions:AccessKey"]));
        }
    }
}
