using Azure.Storage.Blobs;
#nullable enable
namespace BackendApp.Services
{
    public class FileUploadService : IFileUploadService
    {
        private readonly BlobServiceClient _blobServiceClient;

        public FileUploadService(IConfiguration configuration)
        {
            string connectionString = configuration.GetSection("AzureStorage:ConnectionString").Value;
            _blobServiceClient = new BlobServiceClient(connectionString);
        }

        public async Task<string> UploadFile(Stream fileStream, string fileName, string containerName)
        {
            var blobContainerClient = _blobServiceClient.GetBlobContainerClient(containerName);
            var blobClient = blobContainerClient.GetBlobClient(fileName);

            await blobClient.UploadAsync(fileStream, overwrite: true);

            return blobClient.Uri.ToString();
        }
    }

    public interface IFileUploadService
    {
        Task<string> UploadFile(Stream fileStream, string fileName, string containerName);
    }
}
