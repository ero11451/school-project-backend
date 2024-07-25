using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackendApp.Models
{
    public class UserModel
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int id { get; set; }

    [Required]
    // [StringLength(50)]
    public string? Username { get; set; } = null;


    [Required]
    [StringLength(355)]
    public string? Password { get; set; } = null;
    

    // [StringLength(300)]
    [Required]
    public string? Email { get; set; }
    public string? Bio { get; set; }

    // [StringLength(255)]
    public string? UserImgUrl { get; set; }

    public Gender Gender { get; set; } = Gender.Other;

    public UserType UserType { get; set; }

    public Status Status { get; set; } = Status.Active;
    public string? PasswordHash { get; internal set; } = null;
    public string? PasswordSalt { get; internal set; } = null;
    }

public enum Gender
{
    Male,
    Female,
    Other
}

public enum UserType
{
    Voter,
    Admin,
    Candidate
}

public enum Status
{
    Active,
    Inactive,
    Banned
    }
}