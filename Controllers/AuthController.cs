using backend_app.Service;
using BackendApp.Models;
using BackendApp.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BackendApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly TokenService _tokenService;
        private readonly UsersService _usersService;
        private readonly IPasswordHasher<UserModel> _passwordHasher;

        public AuthController(TokenService tokenService, UsersService usersService, IPasswordHasher<UserModel> passwordHasher)
        {
            _tokenService = tokenService;
            _usersService = usersService;
            _passwordHasher = passwordHasher;

        }

        [HttpPost("login")]
         public async Task<IActionResult> Login([FromBody] LoginBody login)
            {
                var user = await _usersService.GetUserByEmailAsync(login.email);
                if (user == null)
                {
                    return Unauthorized();
                }

                var result = _passwordHasher.VerifyHashedPassword(user, user.Password, login.password);
                if (result == PasswordVerificationResult.Success)
                {
                    var token = _tokenService.GenerateToken(login.email);
                    return Ok(new { Token = token, User = user });
                }

                return Unauthorized();
            }


        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterBody register)
        {
            var user = await _usersService.GetUserByEmailAsync(register.email);
            if (user != null)
            {
                return BadRequest("User already exists");
            }
            var hashPassword = _passwordHasher.HashPassword(user, register.Password);
            var newUser = new UserModel
            {
                Email = register.email,
                Password = hashPassword,
                user_name = register.username
            };
            await _usersService.CreateAsync(newUser);
            return Ok();
        }
    }

    public class RegisterBody
    {
        public string email { get; set; }
        public string Password { get; set; }
        public string username { get; set; }
    }

    public class LoginBody
    {
        public string email { get; set; } = null;
        public string password { get; set; } = null;
    }
}
