using BackendApp.Models;
using BackendApp.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackendApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CoursesController : ControllerBase
    {
        private readonly CourseService _courseService;

        public CoursesController(CourseService courseService)
        {
            _courseService = courseService;
        }

        // GET: api/courses
        [HttpGet]
        public async Task<ActionResult<List<CourseModel>>> GetAllCourses(Guid categoryId, int page = 1, int pageSize = 10)
        {
            var courses = await _courseService.GetAllCoursesAsync(categoryId, page, pageSize);
            return Ok(courses);
        }

        // GET: api/courses/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<CourseModel>> GetCourseById(Guid id)
        {
            var course = await _courseService.GetCourseByIdAsync(id);
            if (course == null)
            {
                return NotFound();
            }
            return Ok(course);
        }

        // POST: api/courses
        [HttpPost]
        public async Task<ActionResult<CourseModel>> CreateCourse(CourseCreateDTO request)
        {
            var body = CourseCreateMapper.MapToCourseModel(request);
            var newCourse = await _courseService.CreateCourseAsync(body);
            return CreatedAtAction(nameof(GetCourseById), new { id = newCourse.Id }, newCourse);
        }

        // PUT: api/courses/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<CourseModel>> UpdateCourse(Guid id, CourseCreateDTO course)
        {

            var updatedCourse = await _courseService.UpdateCourseAsync(id, course);
            if (updatedCourse == null)
            {
                return NotFound();
            }
            return Ok(updatedCourse);
        }
        // PUT: api/courses/{id}
        [HttpDelete("delete/{id}")]
        public async Task<ActionResult> DeleteCourse(Guid id)
        {
            var response = await _courseService.DeleteCourse(id); // Ensure await is used
            if (response == null)
            {
                return NotFound();
            }
            return Ok(new {response, message = "Course deleted successfully"});
        }

    }
}
