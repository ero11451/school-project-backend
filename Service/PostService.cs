using AutoMapper;
using BackendApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BackendApp.Services
{
    public class PostService
    {
        private readonly DataBaseContext _context;

        public PostService(DataBaseContext context)
        {
            _context = context;
        }

        public async Task<PagedResult<CourseModel>> GetPostsAsync(
            int page,
            int pageSize,
            Guid? categoryId = null
        )
        {
            var query = _context.Courses.AsQueryable();
            var totalCount = await query.CountAsync();
            if (categoryId.HasValue)
            {
                // query = query.Where(x => x.categoryId == categoryId);
            }
            var posts = await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PagedResult<CourseModel>
            {
                Data = posts,
                Page = page,
                PageSize = pageSize,
                TotalCount = totalCount
            };
        }

        public async Task<CourseModel> GetPostByIdAsync(Guid id)
        {
            return await _context
                .Courses.Include(p => p)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task CreatePostAsync(CourseModel post)
        {
            _context.Courses.Add(post);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePostAsync(CourseModel post)
        {
            _context.Courses.Update(post);
            await _context.SaveChangesAsync();
        }

        public async Task DeletePostAsync(Guid id)
        {
            var post = await _context
                .Courses.Include(p => p)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (post == null)
            {
                throw new NotFoundException("Post not found.");
            }
            _context.Courses.Remove(post);
            await _context.SaveChangesAsync();
        }

        private bool PostExists(Guid id)
        {
            return _context.Courses.Any(e => e.Id == id);
        }
    }
}
