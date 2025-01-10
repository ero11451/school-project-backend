using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using BackendApp.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;

[Route("api/[controller]")]
[ApiController]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)] // Ensure the endpoint is secured and requires an authenticated user
public class ProfileController : ControllerBase
{
    private readonly UserManager<UserModel> _userManager;

    public ProfileController(UserManager<UserModel> userManager)
    {
        _userManager = userManager;
    }

    [HttpGet]
    public async Task<IActionResult> GetProfile()
    {
        // Retrieve the user ID from the JWT claims
        var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

         Console.WriteLine(System.Security.Claims.ClaimTypes.NameIdentifier);
        if (string.IsNullOrEmpty(userId))
            return Unauthorized(new { Message = "User ID not found in token" });

        // Fetch user details from the database using the user ID
        var user = await _userManager.FindByIdAsync(userId);

        if (user == null)
            return NotFound(new { Message = "User not found" });

      
        // Return the user profile
        return Ok(new
        {
            Username = user.UserName,
            Email = user.Email,
            isAdmin = user.UserName == "admin_user" ? true : false,
        });
    }
}
