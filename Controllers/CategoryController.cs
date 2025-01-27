using System;
using Microsoft.AspNetCore.Mvc;
using BackendApp.Models;
using BackendApp.Services;

namespace BackendApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // GET: api/category
        [HttpGet]
        public IActionResult GetAllCategories([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            if (pageNumber < 1 || pageSize < 1)
                return BadRequest("Page number and page size must be greater than 0.");

            var categories = _categoryService.GetAllCategories(pageNumber, pageSize);
            return Ok(categories);
        }

        // GET: api/category/{id}
        [HttpGet("{id}")]
        public IActionResult GetCategoryById(Guid id)
        {
            var category = _categoryService.GetCategoryById(id);
            if (category == null) return NotFound();

            return Ok(category);
        }

        // POST: api/category
        [HttpPost]
        public async Task<IActionResult> CreateCategoryAsync([FromBody] CreateCategoryRequest categoryRequest)
         {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newCategory = await _categoryService.CreateCategory(categoryRequest);
            return Ok(newCategory);
        }

        // PUT: api/category/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(Guid id, [FromBody] UpdateCategoryRequest categoryRequest)
        {
            var updatedCategory = await _categoryService.UpdateCategory(id, categoryRequest);
            if (updatedCategory == null) return NotFound();
            return Ok(updatedCategory);
        }

        // DELETE: api/category/{id}
       [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(Guid id)
        {
            var category = await _categoryService.DeleteCategory(id);
            if (category == null)
            {
                return NotFound(new { Message = "Category not found" });
            }

            return Ok(category);
        }
    }
}
