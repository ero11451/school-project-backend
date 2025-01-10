using BackendApp.Models;
using BackendApp.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BackendApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // GET: api/categories
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet]
        public async Task<ActionResult<List<CategoryModel>>> GetAllCategories()
        {
            var categories = await _categoryService.GetAllCategoriesAsync();
            return Ok(categories);
        }

        // GET: api/categories/{id}
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryModel>> GetCategoryById(Guid id)
        {
            var category = await _categoryService.GetCategoryByIdAsync(id);
            if (category == null)
            {
                return NotFound(new { Message = "Category not found" });
            }
            return Ok(category);
        }

        // DELETE: api/categories/{id}
        [Authorize(Roles = "Admin", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCategory(Guid id)
        {
            var isDeleted = await _categoryService.DeleteCategoryByIdAsync(id);
            // if (isDeleted)
            // {
            //     return NotFound(new { Message = "Category not found or could not be deleted" });
            // }
            return NoContent();
        }

        // POST: api/categories
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult<CategoryModel>> CreateCategory([FromBody] CategoryDTO request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newCategory = await _categoryService.CreateCategoryAsync(request);
            return CreatedAtAction(nameof(GetCategoryById), new { id = newCategory.Id }, newCategory);
        }

        // PUT: api/categories/{id}
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<ActionResult<CategoryModel>> UpdateCategory(Guid id, [FromBody] CategoryDTO request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updatedCategory = await _categoryService.UpdateCategoryAsync(id, request);
            if (updatedCategory == null)
            {
                return NotFound(new { Message = "Category not found" });
            }
            return Ok(updatedCategory);
        }
    }
}
