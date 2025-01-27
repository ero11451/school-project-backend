using System.ComponentModel.DataAnnotations;
using AutoMapper;
using BackendApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BackendApp.Services
{
    public class ClassService : IClassService
    {
        private readonly DataBaseContext _context;
        private readonly IMapper _mapper;

        public ClassService(DataBaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PagedResult<ClassModel>> GetAllClassesAsync(int pageNumber, int pageSize)
        {
            var query = _context.Classes.AsQueryable();
            var totalCount = await query.CountAsync();
            var data = await query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();

            return new PagedResult<ClassModel>
            {
                Data = data,
                Page = pageNumber,
                PageSize = pageSize,
                successful = true,
                TotalCount = totalCount
            };
        }

        public async Task<ClassResponse?> GetClassByIdAsync(Guid id)
        {
            var classData = await _context.Classes.FirstOrDefaultAsync(c => c.Id == id);
            return classData == null ? null : _mapper.Map<ClassResponse>(classData);
        }

        public async Task<ClassModel> CreateClassAsync(ClassRequest classRequest)
        {
            var newClass = _mapper.Map<ClassModel>(classRequest);

            if (classRequest.Tests != null && classRequest.Tests.Any())
            {
                newClass.Tests = classRequest.Tests
                    .Select(testRequest =>
                    {
                        var test = _mapper.Map<TestModel>(testRequest);
                        if (testRequest.Options != null && testRequest.Options.Any())
                        {
                            test.Options = testRequest.Options
                                .Select(optionRequest => _mapper.Map<TestOptionModel>(optionRequest))
                                .ToList();
                        }
                        return test;
                    })
                    .ToList();
            }

            _context.Classes.Add(newClass);
            await _context.SaveChangesAsync();

            return newClass;
        }

        public async Task<ClassResponse?> UpdateClassAsync(Guid id, ClassRequest updatedClass)
        {
            var existingClass = await _context.Classes.FirstOrDefaultAsync(c => c.Id == id);
            if (existingClass == null) return null;

            // Update properties
            _mapper.Map(updatedClass, existingClass);

            if (updatedClass.Tests != null && updatedClass.Tests.Any())
            {
                // Remove existing tests and add new ones
                _context.Tests.RemoveRange(existingClass.Tests);
                existingClass.Tests = updatedClass.Tests.Select(test => _mapper.Map<TestModel>(test)).ToList();
            }

            _context.Classes.Update(existingClass);
            await _context.SaveChangesAsync();

            return _mapper.Map<ClassResponse>(existingClass);
        }

        public async Task<bool> DeleteClassAsync(Guid id)
        {
            var classToDelete = await _context.Classes.FirstOrDefaultAsync(c => c.Id == id);
            if (classToDelete == null) return false;

            _context.Classes.Remove(classToDelete);
            await _context.SaveChangesAsync();
            return true;
        }
    }


    public interface IClassService
    {
        Task<PagedResult<ClassModel>> GetAllClassesAsync(int pageNumber, int pageSize);
        Task<ClassResponse?> GetClassByIdAsync(Guid id);
        Task<ClassModel> CreateClassAsync(ClassRequest classRequest);
        Task<ClassResponse?> UpdateClassAsync(Guid id, ClassRequest updatedClass);
        Task<bool> DeleteClassAsync(Guid id);
    }


}