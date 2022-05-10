using System.IO;
using System.Threading.Tasks;

namespace Schedule.Business.Services.Interfaces
{
    public interface IAzureBlobStorageService : IService
    {
        Task<string> UploadFile(Stream fileStream, string fileName, string extension);
        Task<bool> DeleteFile(string fileId); 
    }
}
