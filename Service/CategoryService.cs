using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using AutoMapper;
using BackendApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BackendApp.Services
{
  

    public interface ICategoryService
    {
        PagedResult<CategoryModel> GetAllCategories(int pageNumber, int pageSize);
        Task<CategoryModel>  GetCategoryById(Guid id);
        Task<CategoryModel> CreateCategory(CreateCategoryRequest categoryRequest);
        Task<CategoryModel?> UpdateCategory(Guid id, UpdateCategoryRequest updatedCategoryRequest);
        Task<CategoryModel?> DeleteCategory(Guid id);
    }

    public class CategoryService : ICategoryService
    {

        private readonly DataBaseContext _context;// Simulated in-memory database
        private readonly IMapper _mapper;
        public CategoryService(DataBaseContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public PagedResult<CategoryModel> GetAllCategories(int pageNumber, int pageSize)
        {
            var query = _context.Categories.AsQueryable();
            var totalCount = query.Count();

            var data = query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

            return new PagedResult<CategoryModel>
            {
                Data = data,
                Page = pageNumber,
                PageSize = pageSize,
                successful = true,
                TotalCount = totalCount
            };
        }

        public Task<CategoryModel> GetCategoryById(Guid id)
        {
            return _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<CategoryModel> CreateCategory(CreateCategoryRequest categoryRequest)
        {
            var category = _mapper.Map<CategoryModel>(categoryRequest);
            
           _context.Categories.Add(category);
            await _context.SaveChangesAsync();
            return category;
        }


    
        // Update an Existing Category
        public async Task<CategoryModel?> UpdateCategory(Guid id, UpdateCategoryRequest updatedCategoryRequest)
        {
            var existingCategory = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
            if (existingCategory == null) return null;

            // Update properties if provided
            if (!string.IsNullOrEmpty(updatedCategoryRequest.CategoryName))
                existingCategory.CategoryName = updatedCategoryRequest.CategoryName;

            if (!string.IsNullOrEmpty(updatedCategoryRequest.Description))
                existingCategory.Description = updatedCategoryRequest.Description;

            _context.Categories.Update(existingCategory);
            await _context.SaveChangesAsync();
            return existingCategory;
        }


         public async Task<CategoryModel?> DeleteCategory(Guid id)
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

    }
}
