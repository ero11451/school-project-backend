using AutoMapper;
using BackendApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BackendApp.Services
{
    public class BlogService : IBlogsServices
    {
        private readonly DataBaseContext _context;
        private readonly IMapper _mapper;

        public BlogService(DataBaseContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<PagedResult<BlogModel>> GetBlogsAsync(
            int page,
            int pageSize,
            Guid? categoryId = null
        )
        {
            var query = _context.Blogs.AsQueryable();
            var totalCount = await query.CountAsync();
            if (categoryId.HasValue)
            {
                // query = query.Where(x => x.categoryId == categoryId);
            }
            var posts = await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PagedResult<BlogModel>
            {
                Data = posts,
                Page = page,
                PageSize = pageSize,
                TotalCount = totalCount
            };
        }

        public async Task<BlogModel> GetBlogByIdAsync(Guid id)
        {
            return await _context
                .Blogs.Include(p => p)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task CreateBlogAsync(BlogRequestDTO body)
        {
            var post = _mapper.Map<BlogModel>(body);
            _context.Blogs.Add(post);
            await _context.SaveChangesAsync();
        }

        public async Task<BlogModel> UpdateBlogAsync(Guid id , BlogRequestDTO body)
        {
            var result = _context.Blogs.FirstOrDefaultAsync(value => value.Id == id);
            if (result == null)
            {
                throw new NotFoundException("Post not found.");
            }
            var updateData =  _mapper.Map(result ,body );
            var res = _mapper.Map<BlogModel>(body);
            _context.Blogs.Update(res);
            await _context.SaveChangesAsync();
            
            return res;
        }

        public async Task<BlogModel> DeleteBlogAsync(Guid id)
        {
            var res = await _context
                .Blogs.Include(p => p)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (res == null)
            {
                throw new NotFoundException("Blog not found.");
            }
            _context.Blogs.Remove(res);
            await _context.SaveChangesAsync();
            return res;
        }
    }

    public interface IBlogsServices {
        Task<PagedResult<BlogModel>> GetBlogsAsync(int page, int pageSize, Guid? categoryId = null);
        Task<BlogModel> GetBlogByIdAsync(Guid id);
        Task CreateBlogAsync(BlogRequestDTO post);
        Task<BlogModel>  UpdateBlogAsync(Guid id,  BlogRequestDTO body);
        Task<BlogModel> DeleteBlogAsync(Guid id);
    }
}
