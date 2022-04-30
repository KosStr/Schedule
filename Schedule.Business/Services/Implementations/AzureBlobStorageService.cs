using Azure.Storage.Blobs;
using Schedule.Business.Services.Interfaces;
using Schedule.Core.Configurations;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Schedule.Business.Services.Implementations
{
    internal class AzureBlobStorageService : IAzureBlobStorageService
    {
        private readonly AzureBlobStorageOptions _azureBlobStorageOptions;
        private readonly BlobServiceClient _blobServiceClient;

        public AzureBlobStorageService(
            AzureBlobStorageOptions azureBlobStorageOptions, 
            BlobServiceClient blobServiceClient)
        {
            _azureBlobStorageOptions = azureBlobStorageOptions;
            _blobServiceClient = blobServiceClient;
        }

        public async Task<string> UploadFile(Stream fileStream, string fileName, string extension)
        {
            var id = $"{Guid.NewGuid()}-{fileName}.{extension}";
            var fileMetadata = new Dictionary<string, string>
                { { "Name", fileName }, { "Parents", _azureBlobStorageOptions.Container } };

            var blobContainerClient = _blobServiceClient.GetBlobContainerClient(_azureBlobStorageOptions.Container);
            var blobClient = blobContainerClient.GetBlobClient(id);

            await blobClient.UploadAsync(fileStream, true);
            await blobClient.SetMetadataAsync(fileMetadata);

            return id;
        }

        public async Task<bool> DeleteFile(string fileId)
        {
            var blobContainerClient = _blobServiceClient.GetBlobContainerClient(_azureBlobStorageOptions.Container);
            var response = await blobContainerClient.DeleteBlobIfExistsAsync(fileId);

            return response.Value;
        }
    }
}
