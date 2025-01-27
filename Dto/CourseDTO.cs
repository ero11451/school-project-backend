using System.ComponentModel.DataAnnotations;


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




