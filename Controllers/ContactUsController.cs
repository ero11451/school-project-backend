using BackendApp.Models;
using BackendApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace BackendApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactUsController : ControllerBase
    {
        private readonly IContactUsService _service;

        public ContactUsController(IContactUsService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<ContactModel>>> Get()
        {
            var data = await _service.GetAllAsync();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ContactModel>> GetAsync(Guid id)
        {
            var data = await _service.GetByIdAsync(id);
            if (data == null)
            {
                return NotFound(new { Message = "Contact message not found" });
            }
            return Ok(data);
        }

        [HttpPost]
        public async Task<ActionResult<ContactRequest>> Post([FromBody] ContactRequest value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var data = await _service.CreateAsync(value);
            return Ok(data);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ContactModel>> Put(Guid id, [FromBody] ContactModel value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updatedData = await _service.UpdateAsync(id, value);
            if (updatedData == null)
            {
                return NotFound(new { Message = "Contact message not found" });
            }
            return Ok(updatedData);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var isDeleted = await _service.DeleteByIdAsync(id);
            if (isDeleted == null)
            {
                return NotFound(new { Message = "Contact message not found or could not be deleted" });
            }
            return NoContent();
        }
    }
}
