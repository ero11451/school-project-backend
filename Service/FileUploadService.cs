using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Microsoft.Extensions.Configuration;

namespace BackendApp.Services
{
    public class FileUploadService : IFileUploadService
    {
        private readonly BlobServiceClient _blobServiceClient;
        string connectionString =  "";


        public FileUploadService(IConfiguration configuration)
        {
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
