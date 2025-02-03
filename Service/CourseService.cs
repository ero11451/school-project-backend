using AutoMapper.QueryableExtensions;
using BackendApp.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace BackendApp.Services
{
    public interface ICourseService
    {
        PagedResult<CourseResponseDTO> GetAllCourses(int pageNumber, int pageSize, Guid? categoryId , string sort );
        Task<CourseModel> GetCourseById(Guid id);
        Task<CourseModel> CreateCourse(CourseModel course);
        CourseModel UpdateCourse(Guid id, CourseModel updatedCourse);
        Task<CourseModel?> DeleteCourse(Guid id);
    }

    public class CourseService : ICourseService
    {
         private readonly DataBaseContext _context;
        private readonly IMapper _mapper;

        public CourseService(DataBaseContext context , IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }


public PagedResult<CourseResponseDTO> GetAllCourses(int pageNumber, int pageSize, Guid? categoryId = null, string sort = null)
{
    var query = _context.Courses
        .Include(c => c.Creator)
        .Select(c => new CourseResponseDTO{
            CategoryId = c.CategoryId,
            CourseName = c.CourseName,
            CreatedAt = c.CreatedAt,
            Id = c.Id,
            Description = c.Description,
            Status = c.Status,
            ThumbnailUrl = c.ThumbnailUrl,
            TotalClasses = c.Classes.Count,
            Creator = new CreatorRespondsDTO {
                Email = c.Creator.Email,
                UserName = c.Creator.UserName,
                UserImgUrl = c.Creator.UserImgUrl
            }

        }) 
        .AsQueryable();

    // 🔹 Apply Filtering
    if (categoryId.HasValue)
    {
        query = query.Where(c => c.CategoryId == categoryId.Value);
    }

    // 🔹 Apply Sorting
    query = sort?.ToLowerInvariant() switch
    {
        "name" => query.OrderBy(c => c.CourseName),
        "name_desc" => query.OrderByDescending(c => c.CourseName),
        "date" => query.OrderBy(c => c.CreatedAt),
        "date_desc" => query.OrderByDescending(c => c.CreatedAt),
        _ => query.OrderBy(c => c.Id) // Default sorting by ID
    };

    // 🔹 Get Total Count before pagination
    int totalCount = query.Count();

    // 🔹 Apply Pagination & Use `ProjectTo<T>()`
    var data = query
        .Skip((pageNumber - 1) * pageSize)
        .Take(pageSize)
        .ToList();

    return new PagedResult<CourseResponseDTO>
    {
        Data = data,
        Page = pageNumber,
        PageSize = pageSize,
        successful = true,
        TotalCount = totalCount
    };
}
 public async Task<CourseModel> GetCourseById(Guid id)
        {
            return await _context.Courses.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<CourseModel> CreateCourse(CourseModel course)
        {
            _context.Courses.Add(course);
            await _context.SaveChangesAsync();
            // _courses.Add(course);
            return course;
        }

        public CourseModel UpdateCourse(Guid id, CourseModel updatedCourse)
        {
            // var existingCourse = _context.Courses.FirstOrDefault(c => c.Id == id);
            // if (existingCourse == null) return null;

            // existingCourse.CourseName = updatedCourse.CourseName;
            // existingCourse.Description = updatedCourse.Description;
            // existingCourse.Status = updatedCourse.Status;
            // existingCourse.ThumbnailUrl = updatedCourse.ThumbnailUrl;
            // existingCourse.Classes = updatedCourse.Classes;
            // existingCourse.Creator = updatedCourse.Creator;

            return updatedCourse;
        }

        public async Task<CourseModel?> DeleteCourse(Guid id)
        {
           var Courses = await _context.Courses.FirstOrDefaultAsync(c => c.Id == id);
            if (Courses == null)
            {
                return null;
            }

            _context.Courses.Remove(Courses);
            await _context.SaveChangesAsync();

            return Courses;
        }

       
    }
}
