using BackendApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace BackendApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileUpload : ControllerBase
    {
        private readonly IFileUploadService _fileUploadService;
        public FileUpload(IFileUploadService fileUploadService)
        {
            _fileUploadService = fileUploadService;
        }

        [HttpPost]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("File not selected");
            }
            var result = await _fileUploadService.UploadFile(
                file.OpenReadStream(),
                file.FileName,
                "neebohfilecontainer"
            );
            return Ok(new { fileUrl = result });
        }

      }
}
