using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using BackendApp.Models;
using System.ComponentModel.DataAnnotations;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly UserManager<UserModel> _userManager;
    private readonly SignInManager<UserModel> _signInManager;
    private readonly IConfiguration _configuration;

    public AuthController(
        UserManager<UserModel> userManager,
        SignInManager<UserModel> signInManager,
        IConfiguration configuration)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _configuration = configuration;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterModel model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var user = new UserModel
        {
            UserName = model.UserName,
            Email = model.Email
        };

        var result = await _userManager.CreateAsync(user, model.Password);

        if (!result.Succeeded)
        {
            return BadRequest(new { Errors = result.Errors.Select(e => e.Description) });
        }

        return Ok(new { Message = "User registered successfully" });
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginModel model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var user = await _userManager.FindByEmailAsync(model.Email);
        if (user == null || !await _userManager.CheckPasswordAsync(user, model.Password))
        {
            return Unauthorized(new { Message = "Invalid email or password" });
        }

        var token = GenerateJwtToken(user);

        return Ok(new
        {
            token = new JwtSecurityTokenHandler().WriteToken(token),
            expiration = token.ValidTo
        });
    }

    


   private JwtSecurityToken GenerateJwtToken(UserModel user)
{
    // Fetch settings from configuration
    string jwtKey = _configuration["Jwt:Key"];
    string jwtIssuer = _configuration["Jwt:Issuer"];
    string jwtAudience = _configuration["Jwt:Audience"];

    // Validate the JWT key
    if (string.IsNullOrEmpty(jwtKey) || jwtKey.Length < 32)
    {
        throw new ArgumentException("JWT key must be at least 32 characters long.");
    }

    // Prepare claims
    var authClaims = new List<Claim>
    {
        new Claim(ClaimTypes.NameIdentifier, user.Id), // Include user ID
        new Claim(ClaimTypes.Name, user.UserName),
        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
    };

    // Add the Admin role claim if applicable
    if (user.UserName.Equals("admin_user", StringComparison.OrdinalIgnoreCase))
    {
        authClaims.Add(new Claim(ClaimTypes.Role, "Admin"));
    }

    // Create signing key
    var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));

    // Generate the JWT token
    return new JwtSecurityToken(
        issuer: jwtIssuer,
        audience: jwtAudience,
        expires: DateTime.UtcNow.AddHours(1), // Use UTC for consistency
        claims: authClaims,
        signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
    );
}

}

public class RegisterModel
{
    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid email address")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Password is required")]
    [MinLength(6, ErrorMessage = "Password must be at least 6 characters long")]
    public string Password { get; set; }

    [Required(ErrorMessage = "Username is required")]
    public string UserName { get; set; }
}

public class LoginModel
{
    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid email address")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Password is required")]
    public string Password { get; set; }
}
