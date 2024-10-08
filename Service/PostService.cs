using AutoMapper;
using BackendApp.Data;
using BackendApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BackendApp.Services
{
    public class PostService
    {
        private readonly AppDbContext _context;
        // private readonly IMapper _mapper;

        public PostService(AppDbContext context)
        {
            // _mapper = mapper;
            _context = context;
        }

        public async Task<PagedResult<PostModel>> GetPostsAsync(
            int page,
            int pageSize,
            int? categoryId = null
        )
        {
            var query = _context.PostModel.AsQueryable();
            var totalCount = await query.CountAsync();
            if (categoryId.HasValue)
            {
                query = query.Where(x => x.CategoryId == categoryId);
            }
            var posts = await query
                .Include(p => p.Category)
                .Include(p => p.Options)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PagedResult<PostModel>
            {
                Data = posts,
                Page = page,
                PageSize = pageSize,
                TotalCount = totalCount
            };
        }

        public async Task<PostModel> GetPostByIdAsync(int id)
        {
            return await _context
                .PostModel.Include(p => p.Options)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task CreatePostAsync(PostModel post)
        {
            _context.PostModel.Add(post);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePostAsync(PostModel post)
        {
            _context.PostModel.Update(post);
            await _context.SaveChangesAsync();
        }

        public async Task DeletePostAsync(int id)
        {
            var post = await _context
                .PostModel.Include(p => p.Options)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (post == null)
            {
                throw new NotFoundException("Post not found.");
            }

            _context.PostModel.Remove(post);
            await _context.SaveChangesAsync();
        }

        private bool PostExists(int id)
        {
            return _context.PostModel.Any(e => e.Id == id);
        }
    }
}
