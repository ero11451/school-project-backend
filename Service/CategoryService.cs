using BackendApp.Data;
using BackendApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BackendApp.Service;

public class CategoryService
{
    private readonly AppDbContext _context;

    public CategoryService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<CategoryModel>> GetAsync()
    {
        return await _context.CategoryModel.ToListAsync();
    }

    public async Task<CategoryModel> GetByIdAsync(int id)
    {
        return await _context.CategoryModel.FindAsync(id);
    }

    public async Task CreateAsync(CategoryModel data)
    {
        _context.CategoryModel.Add(data);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(CategoryModel data)
    {
        _context.CategoryModel.Update(data);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var data = await _context.CategoryModel.FindAsync(id);
        if (data != null)
        {
            _context.CategoryModel.Remove(data);
            await _context.SaveChangesAsync();
        }
    }
}
