using BackendApp.Data;
using BackendApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace backend_app.Service
{
    public class UsersService(AppDbContext context) 
    {
        private readonly AppDbContext _context = context;
        public async Task<List<UserModel>> GetAsync()
        {
            return await _context.UserModel.ToListAsync();
        }

        public async Task<UserModel> GetByIdAsync(int id)
        {
            return await _context.UserModel.FindAsync(id);
        }
        public async Task<UserModel> GetByEmailAsync(string email)
        {
            return await _context.UserModel.FirstOrDefaultAsync((user) => user.Email == email);
        }
   

        public async Task CreateAsync(UserModel user)
        {
            _context.UserModel.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePostAsync(UserModel user)
        {
            _context.UserModel.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeletePostAsync(int id)
        {
            var user = await _context.UserModel.FindAsync(id);
            if (user != null)
            {
                _context.UserModel.Remove(user);
                await _context.SaveChangesAsync();
            }
        }
        public bool UserExists(string email)
        {
            return _context.UserModel.Any(e => e.Email == email);
        }
    }


   

}
