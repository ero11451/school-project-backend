using Microsoft.AspNetCore.Identity;

namespace BackendApp.Models
{
    public class UserModel : IdentityUser
  {
    public string? user_name { get; set; } = null;
    public string? Password { get; set; } 
    // public string? Phone { get; set; }
    public string? Bio { get; set; }

    // [StringLength(255)]
    public string? UserImgUrl { get; set; }

    public Gender? Gender { get; set; }

    public UserType? UserType { get; set; }

    public Status? Status { get; set; }
    }

public enum Gender
{
    Male,
    Female,
    Other
}

public enum UserType
{
    gest,
    Admin,
    creator
}

public enum Status
{
    Active,
    Inactive,
    Banned
    }
}