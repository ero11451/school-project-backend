using BackendApp.Data;
using BackendApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BackendApp.Services
{
    public class PostService
    {
        private readonly AppDbContext _context;

        public PostService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<PostModel>> GetPostsAsync()
        {
            return await _context.PostModel.ToListAsync();
        }

        public async Task<PostModel> GetPostByIdAsync(int id)
        {
            return await _context.PostModel.FindAsync(id);
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
            var post = await _context.PostModel.FindAsync(id);
            if (post != null)
            {
                _context.PostModel.Remove(post);
                await _context.SaveChangesAsync();
            }
        }

         private bool PostExists(int id)
        {
            return _context.PostModel.Any(e => e.id == id);
        }
    }
}
