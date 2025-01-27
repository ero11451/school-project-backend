using System;
using System.Collections.Generic;
using System.Linq;
using BackendApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BackendApp.Services
{
    public interface ICourseService
    {
        PagedResult<CourseModel> GetAllCourses(int pageNumber, int pageSize);
        Task<CourseModel> GetCourseById(Guid id);
        Task<CourseModel> CreateCourse(CourseModel course);
        CourseModel UpdateCourse(Guid id, CourseModel updatedCourse);
        Task<CourseModel?> DeleteCourse(Guid id);
    }

    public class CourseService : ICourseService
    {
         private readonly DataBaseContext _context;

        public CourseService(DataBaseContext context)
        {
            _context = context;
        }


        public PagedResult<CourseModel> GetAllCourses(int pageNumber, int pageSize)
        {
            var query = _context.Courses.AsQueryable();
            var totalCount = query.Count();

            var data = query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

            return new PagedResult<CourseModel>
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
            // var existingCourse = _courses.FirstOrDefault(c => c.Id == id);
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
