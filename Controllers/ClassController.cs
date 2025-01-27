using System;
using Microsoft.AspNetCore.Mvc;
using BackendApp.Models;
using BackendApp.Services;

namespace BackendApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClassController : ControllerBase
    {
        private readonly IClassService _classService;

        public ClassController(IClassService classService)
        {
            _classService = classService;
        }

        // GET: api/class
        [HttpGet]
        public  async Task<IActionResult> GetAllClasses( [FromQuery] int pageNumber = 1, [FromQuery]int pageSize = 10)
        {
            var classes = await  _classService.GetAllClassesAsync(pageNumber,  pageSize);
            return Ok(classes);
        }

        // GET: api/class/{id}
        [HttpGet("{id}")]
        public IActionResult GetClassById(Guid id)
        {
            var classModel = _classService.GetClassByIdAsync(id);
            if (classModel == null) return NotFound();

            return Ok(classModel);
        }

        // POST: api/class
        [HttpPost]
        public async Task<IActionResult> CreateClass([FromBody] ClassRequest classModel)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var createdClass = await _classService.CreateClassAsync(classModel);
            
            return Ok(new{data = createdClass, message = "Class created successfully"});
        }

        // PUT: api/class/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateClass(Guid id, [FromBody] ClassRequest updatedClass)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var updated = _classService.UpdateClassAsync(id, updatedClass);
            if (updated == null) return NotFound();

            return Ok(updated);
        }

        // DELETE: api/class/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClass(Guid id)
        {
            var result = await _classService.DeleteClassAsync(id);
            if (!result) return NotFound();

            return NoContent();
        }
    }
}
