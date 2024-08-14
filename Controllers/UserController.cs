using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using BackendApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using backend_app.Service;
using BackendApp.Services;


namespace BackendApp.Controllers
{
    // [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly TokenService _tokenService;
        private readonly UsersService _usersService;

        public UserController(TokenService tokenService, UsersService usersService)
        {
            _tokenService = tokenService;
            _usersService = usersService;
        }

        [HttpGet]
        // [Authorize]
        public async Task<ActionResult<IEnumerable<UserModel>>>
        GetAsync(int page, int pageSize)
        {
            var users = await _usersService.GetAllUsersAsync(page, pageSize);
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            if (id == null)
            {
                BadRequest("No id provided");
            }
            var user = await _usersService.GetUserByIdAsync(id);
            if (user == null)
            {
                return BadRequest("User not found");
            }

            return Ok(user);
        }

        // [Authorize]
        [HttpGet("profile")]
        public IActionResult GetProfile()
        {
            // Get the token from the Authorization header
            var authHeader = Request.Headers["Authorization"].ToString();
            if (string.IsNullOrEmpty(authHeader) || !authHeader.StartsWith("Bearer "))
            {
                return Unauthorized();
            }

            // Extract the token by removing the "Bearer " prefix
            var token = authHeader.Substring("Bearer ".Length).Trim();

            // _usersService.
            var userDataToken = _tokenService.ValidateToken(token);

            // De;code the token to get the user claims (optional step)
            // var handler = new JwtSecurityTokenHandler();
            // var jsonToken = handler.ReadToken(token) as JwtSecurityToken;
            // var userId = jsonToken.Claims.First(claim => claim.Type == "sub").Value;

            // Alternatively, you can use the User.Identity claims if authenticated middleware is in place
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var email = User.FindFirstValue(ClaimTypes.Email);
            var username = User.Identity.Name;

            return Ok(new { Token = token, userDataToken = userDataToken, UserId = userId, Username = username, Email = email });
        }


        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/users/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult>
        UpdateUser(string id, [FromBody] UserModel user)
        {
            if (id != user.Id)
            {
                return BadRequest("User ID mismatch");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _usersService.UpdateUserAsync(user);
                return NoContent();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (DbUpdateConcurrencyException)
            {
                return StatusCode(500,
                "A concurrency error occurred. Please try again.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
              try
            {
                await _usersService.DeleteUserAsync(id);
                return Ok();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (DbUpdateConcurrencyException)
            {
                return StatusCode(500,
                "A concurrency error occurred. Please try again.");
            }
        }
    }
}
