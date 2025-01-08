using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using BackendApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BackendApp.Services;


namespace BackendApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly CategoryService _categoryService;

        public CategoriesController(CategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // GET: api/categories
        [HttpGet]
        public async Task<ActionResult<List<CategoryModel>>> GetAllCategories()
        {
            var categories = await _categoryService.GetAllCategoriesAsync();
            return Ok(categories);
        }

        // GET: api/categories/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryModel>> GetCategoryById(Guid id)
        {
            var category = await _categoryService.GetCategoryByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        // Delete: api/categories/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult<CategoryModel>> DeleteCategory(Guid id)
        {
            var category = await _categoryService.DeleteCategoryByIdAsync(id);
            return Ok(category);
        }

        // POST: api/categories
        [HttpPost]
        public async Task<ActionResult<CategoryModel>> CreateCategory(CategoryDTO request)
        {
            var category = new CategoryDTO().createCategoryDto(request);
            var newCategory = await _categoryService.CreateCategoryAsync(category);
            return CreatedAtAction(nameof(GetCategoryById), new { id = newCategory.Id }, newCategory);
        }

        // PUT: api/categories/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<CategoryModel>> UpdateCategory(Guid id, CategoryModel category)
        {
            var updatedCategory = await _categoryService.UpdateCategoryAsync(id, category);
            if (updatedCategory == null)
            {
                return NotFound();
            }
            return Ok(updatedCategory);
        }
    }
}
