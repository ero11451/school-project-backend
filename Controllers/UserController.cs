using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using BackendApp.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;

namespace BackendApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)] 
    // [Authorize(Roles = "Admin")] // Only admins can manage users
    public class UserController : ControllerBase
    {
        private readonly UserManager<UserModel> _userManager;

        public UserController(UserManager<UserModel> userManager)
        {
            _userManager = userManager;
        }

        // CREATE: Add a new user
        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserModel model)
        {
            var user = new UserModel
            {
                UserName = model.UserName,
                Email = model.Email
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            return Ok(new { Message = "User created successfully.", UserId = user.Id });
        }

        // READ: Get a list of all users
        [HttpGet]
        public async Task<IActionResult> GetAllUsers(int page = 1, int pageSize = 10)
        {
            var users = await _userManager.Users.ToListAsync();
            return Ok(users.Select(user => new
            {
                user.Id,
                user.UserName,
                user.Email,
                user.Phone   
            }));
        }

        // READ: Get a user by ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(new
            {
                user.Id,
                user.UserName,
                user.Email
            });
        }

        // UPDATE: Update an existing user
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(string id, UpdateUserModel model)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            user.UserName = model.UserName ?? user.UserName;
            user.Email = model.Email ?? user.Email;

            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            return Ok(new { Message = "User updated successfully." });
        }

        // DELETE: Delete a user
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            var result = await _userManager.DeleteAsync(user);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            return Ok(new { Message = "User deleted successfully." });
        }
    }
}
