using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using BackendApp.Models;

public class AuthService
{
    private readonly UserManager<UserModel> _userManager;
    private readonly IConfiguration _configuration;

    public AuthService(UserManager<UserModel> userManager, IConfiguration configuration)
    {
        _userManager = userManager;
        _configuration = configuration;
    }

    public async Task<IdentityResult> RegisterUserAsync(RegisterModel model)
    {
        var user = new UserModel
        {
            UserName = model.UserName,
            Email = model.Email
        };

        return await _userManager.CreateAsync(user, model.Password);
    }

    public async Task<UserModel> ValidateUserAsync(LoginModel model)
    {
        var user = await _userManager.FindByEmailAsync(model.Email);
        if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
        {
            return user;
        }
        return null;
    }

   public JwtSecurityToken GenerateJwtToken(UserModel user)
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


    public interface IAuthService
    {
        Task<IdentityResult> RegisterUserAsync(RegisterModel model);
        Task<UserModel> ValidateUserAsync(LoginModel model);
        JwtSecurityToken GenerateJwtToken(UserModel user);
    }
