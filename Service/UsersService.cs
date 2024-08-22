using BackendApp.Data;
using BackendApp.Models;
using BackendApp.Services;
using Microsoft.EntityFrameworkCore;
using SendGrid.Helpers.Errors.Model;

namespace BackendApp.Services
{
    public class UsersService
    {
        // private readonly TokenService _tokenService;
        private readonly AppDbContext _context;

        public UsersService(AppDbContext context)
        {
            // _tokenService = tokenService;
            _context = context;
        }

        // Get all users
        public async Task<PagedResult<UserModel>>
        GetAllUsersAsync(int page, int pageSize)
        {
            var query = _context.UserModel.AsQueryable();
            var totalCount = await query.CountAsync();
            var users =
                await query
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();

            return new PagedResult<UserModel> {
                Data = users,
                Page = page,
                PageSize = pageSize,
                TotalCount = totalCount
            };
        }

        // Get a user by their ID
        public async Task<UserModel> GetUserByIdAsync(string id)
        {
            return await _context.UserModel.FindAsync(id);
        }

        // Get a user by their email
        public async Task<UserModel> GetUserByEmailAsync(string email)
        {
            return await _context
                .UserModel
                .FirstOrDefaultAsync(user => user.Email == email);
        }

        // Create a new user
        public async Task CreateAsync(UserModel user)
        {
            _context.UserModel.Add (user);
            await _context.SaveChangesAsync();
        }

        // Update an existing user
        public async Task UpdateUserAsync(UserModel user)
        {
            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(user.Id))
                {
                    throw new NotFoundException("User not found.");
                }
                else
                {
                    throw; // Re-throw the exception to be handled at a higher level
                }
            }
        }

        // Delete a user by their ID
        public async Task DeleteUserAsync(string id)
        {
            var user = await _context.UserModel.FindAsync(id);
            if (user == null)
            {
                throw new NotFoundException("User not found.");
            }
            _context.UserModel.Remove (user);
            await _context.SaveChangesAsync();
        }

        // Check if a user exists by email
        public bool UserExists(string email)
        {
            return _context.UserModel.Any(e => e.Email == email);
        }

        internal async Task GetAllUsersAsync()
        {
            throw new NotImplementedException();
        }
    }

   
}
