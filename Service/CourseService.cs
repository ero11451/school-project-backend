using BackendApp.Models;
using Microsoft.EntityFrameworkCore;
namespace BackendApp.Services;

public class CourseService 
{
    private readonly DataBaseContext _context;

    public CourseService(DataBaseContext context)
    {
        _context = context;
    }

    public async Task<PagedResult<CourseDTO>> GetAllCoursesAsync(Guid categoryId, int page, int pageSize)
    {
        var query = _context.Courses.AsQueryable();
        var totalCount = await query.CountAsync();
        if (categoryId != null)
        {
            query.Where(c => c.Id == categoryId);
        }

        var posts = await query.Skip((page - 1) * pageSize)
           .Select(c => new CourseDTO
           {
               Id = c.Id,
               Title = c.Title,
               Content = c.Content,
               ImgUrl = c.ImgUrl,
               CategoryId = c.CategoryId,
               Teacher = new CourseDTO.TeacherDTO{
                  UserName = c.Teacher.UserName,
                  Email = c.Teacher.Email,
                  ImgUrl = c.Teacher.UserimgUrl
               }
           })
            .ToListAsync();

        return new PagedResult<CourseDTO>
        {
            Data = posts,
            Page = page,
            PageSize = pageSize,
            successful = true,
            TotalCount = totalCount
        };
    }

    public async Task<CourseModel?> GetCourseByIdAsync(Guid id)
    {
        return await _context.Courses
            .Include(c => c.Category)
            .Include(c => c.Teacher)
            .Include(c => c.Options)
            .FirstOrDefaultAsync(c => c.Id == id)
            // .Select(c => new CourseModel
            // {
            //     Id = c.Id,
            //     Title = c.Title,
            //     Content = c.Content,
            //     ImgUrl = c.ImgUrl,
            //     CategoryId = c.CategoryId,
            //     TeacherId = c.TeacherId,
            //     Question = c.Question,
            //     Options = c.Options.Select(o => new OptionModel
            //     {
            //         Id = o.Id,
            //         Title = o.Title,
            //         IsCorrect = o.IsCorrect
            //     })
            // })
            ;
    }

    public async Task<CourseModel> CreateCourseAsync(CourseModel course)
    {
        _context.Courses.Add(course);
        await _context.SaveChangesAsync();
        return course;
    }

    public async Task<CourseModel?> UpdateCourseAsync(Guid id, CourseCreateDTO updatedCourse)
    {
        var course = await _context.Courses.FindAsync(id);
        if (course == null)
        {
            return null;
        }

        // Update properties
        course.Title = updatedCourse.Title;
        course.Content = updatedCourse.Content;
        course.Summary = updatedCourse.Summary;
        course.ImgUrl = updatedCourse.ImgUrl;
        course.Code = updatedCourse.Code;
        course.VideoUrl = updatedCourse.VideoUrl;
        course.Status = updatedCourse.Status;
        course.CategoryId = updatedCourse.CategoryId;
        course.TeacherId = updatedCourse.TeacherId;
        course.Question = updatedCourse.Question;

        _context.Courses.Update(course);
        await _context.SaveChangesAsync();

        return course;
    }

public async Task<bool> DeleteCourse(Guid id)
{
    var query = await _context.Courses.FindAsync(id); // Ensure proper async handling
    
    if (query == null)
    {
        return false; // Return a value if course not found
    }

    _context.Courses.Remove(query);

    await _context.SaveChangesAsync(); // Use async version of SaveChanges
    return true;
}


  
}




public interface ICourseService
{
    Task<PagedResult<CourseDTO>> GetAllCoursesAsync(int page, int pageSize, Guid categoryId);
    Task<CourseModel?> GetCourseByIdAsync(Guid id);
    Task<CourseModel> CreateCourseAsync(CourseModel course);
    Task<CourseModel?> UpdateCourseAsync(Guid id, CourseCreateDTO updatedCourse);
    Task DeleteCourse(Guid id);

}