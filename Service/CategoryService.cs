using BackendApp.Models;
using BackendApp.Services;
using Microsoft.EntityFrameworkCore;


namespace BackendApp.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly DataBaseContext _context;

        public CategoryService(DataBaseContext context)
        {
            _context = context;
        }

        public async Task<List<CategoryModel>> GetAllCategoriesAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<CategoryModel?> DeleteCategoryByIdAsync(Guid id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return null;
            }

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();

            return category;
        }
        public async Task<CategoryModel?> GetCategoryByIdAsync(Guid id)
        {
            return await _context.Categories
            .Include(c => c.Courses)
            .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<CategoryModel> CreateCategoryAsync(CategoryModel category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<CategoryModel?> UpdateCategoryAsync(Guid id, CategoryModel updatedCategory)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return null;
            }

            // Update properties
            category.Name = updatedCategory.Name;
            category.Description = updatedCategory.Description;
            category.CreatedTimestamp = updatedCategory.CreatedTimestamp;

            _context.Categories.Update(category);
            await _context.SaveChangesAsync();

            return category;
        }
    }



    public interface ICategoryService
    {
        Task<List<CategoryModel>> GetAllCategoriesAsync();
        Task<CategoryModel?> GetCategoryByIdAsync(Guid id);
        Task<CategoryModel?> DeleteCategoryByIdAsync(Guid id);
        Task<CategoryModel> CreateCategoryAsync(CategoryModel category);
        Task<CategoryModel?> UpdateCategoryAsync(Guid id, CategoryModel updatedCategory);
    }
}

