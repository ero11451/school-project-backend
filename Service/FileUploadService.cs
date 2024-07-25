using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using System.Threading.Tasks;

namespace BackendApp.Services
{
    public class FileUploadService : IFileUploadService
    {
        private readonly string _storagePath;

        public FileUploadService(IWebHostEnvironment env)
        {
            if (env == null)
            {
                throw new ArgumentNullException(nameof(env), "WebHostEnvironment cannot be null");
            }

            _storagePath = Path.Combine(env.ContentRootPath ?? throw new ArgumentNullException(nameof(env.ContentRootPath)), "uploads");
            if (!Directory.Exists(_storagePath))
            {
                Directory.CreateDirectory(_storagePath);
            }
        }

        public async Task<string> UploadFileAsync(IFormFile file)
        {
            if (file == null)
            {
                throw new ArgumentNullException(nameof(file), "File cannot be null");
            }

            if (file.Length > 0)
            {
                var filePath = Path.Combine(_storagePath, file.FileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                return filePath;
            }

            return null;
        }

    }

    public interface IFileUploadService
    {
        Task<string>  UploadFileAsync(IFormFile file);
    }
}
