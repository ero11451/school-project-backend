using BackendApp.Service;
using BackendApp.Models;
using BackendApp.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace backend_app.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
       private readonly CategoryService _categoryService;
       public CategoryController (CategoryService categoryService) {
              _categoryService = categoryService;
       }

       [HttpGet]
       public async Task<ActionResult<List<CategoryModel>>> GetCategories(){
            var categories = await _categoryService.GetAsync();
            return Ok(categories);
        }

        
       [HttpPost]
       public async Task<ActionResult> CreateCategory(CategoryRequest category){
            var categoryNew = new CategoryModel{
                category = category.category
             };
            await _categoryService.CreateAsync(categoryNew);
            return CreatedAtAction(nameof(GetCategories), categoryNew);
        }
        
    }

    public class CategoryRequest
    {
        public string category { get; set; }
    }
   
}
