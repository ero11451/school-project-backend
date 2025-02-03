using Microsoft.AspNetCore.Mvc;
using BackendApp.Models;
using BackendApp.Services;

namespace BackendApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        // GET: api/course f
        [HttpGet]
        public IActionResult GetAllCourses(
            [FromQuery] int pageNumber = 1, 
            [FromQuery] int pageSize = 10, 
            Guid? categoryId = null, 
            string? sort = null)
        {
            if (pageNumber < 1 || pageSize < 1)
                return BadRequest("Page number and page size must be greater than 0.");

            var courses = _courseService.GetAllCourses(pageNumber, pageSize, categoryId, sort);
            return Ok(courses);
        }

        // GET: api/course/{id}
        [HttpGet("{id}")]
        public IActionResult GetCourseById(Guid id)
        {
            var course = _courseService.GetCourseById(id);
            if (course == null) return NotFound();

            return Ok(course);
        }

        // POST: api/course
        [HttpPost]
        public async Task<IActionResult> CreateCourse([FromBody] CreateCourseRequest courseRequest)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var courseModel = new CourseModel
            {
                CourseName = courseRequest.CourseName,
                Description = courseRequest.Description,
                ThumbnailUrl = courseRequest.ThumbnailUrl,
                Status = courseRequest.Status,
                CreatorId = courseRequest.CreatorId,
                CategoryId = courseRequest.CategoryId
            };

            var createdCourse = await _courseService.CreateCourse(courseModel);

            return CreatedAtAction(nameof(GetCourseById), createdCourse);
        }

        // PUT: api/course/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateCourse(Guid id, [FromBody] UpdateCourseRequest courseRequest)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var updatedCourse = new CourseModel
            {
                CourseName = courseRequest.CourseName,
                Description = courseRequest.Description,
                ThumbnailUrl = courseRequest.ThumbnailUrl,
                Status = courseRequest.Status,
                CreatorId = courseRequest.CreatorId,
                CategoryId = courseRequest.CategoryId
            };

            var updated = _courseService.UpdateCourse(id, updatedCourse);
            if (updated == null) return NotFound();

            return Ok(updated);
        }

        // DELETE: api/course/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(Guid id)
        {
            var result = await _courseService.DeleteCourse(id);
            if (result == null) return NotFound();

            return NoContent();
        }
    }

}