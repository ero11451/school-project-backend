using System.ComponentModel.DataAnnotations;
using BackendApp.Models;


public class CreateCourseRequest
{
    [Required]
    [MaxLength(200)]
    public string CourseName { get; set; }

    [Required]
    public string Description { get; set; }

    public string? ThumbnailUrl { get; set; }

    [Required]
    public string Status { get; set; }

    [Required]
    public string CreatorId { get; set; }

    [Required]
    public Guid CategoryId { get; set; }
}

public class UpdateCourseRequest
{
    [Required]
    [MaxLength(200)]
    public string CourseName { get; set; }

    [Required]
    public string Description { get; set; }

    public string? ThumbnailUrl { get; set; }

    [Required]
    public string Status { get; set; }

    [Required]
    public string CreatorId { get; set; }

    [Required]
    public Guid CategoryId { get; set; }
}

// ff

public class CourseResponseDTO
{

    public Guid Id { get; set; }
    public string CourseName { get; set; }
    [Required]
    public string Description { get; set; }
    public string? ThumbnailUrl { get; set; }
    [Required]
    public string Status { get; set; }
    [Required]
    public string CreatorId { get; set; }
    [Required]
    public Guid CategoryId { get; set; }
    public DateTime CreatedAt { get; set; }
    public int? TotalClasses { get; set; }
    public CreatorRespondsDTO ? Creator { get; set; } 
}

public class CreatorRespondsDTO
{
    public string UserName { get; set; }
    public string Email { get; set; }
    public string UserImgUrl { get; set; }
   

}
