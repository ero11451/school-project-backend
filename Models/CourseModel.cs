using System.ComponentModel.DataAnnotations;

namespace BackendApp.Models
{
    public class CourseModel
    {
        [Key]
        public Guid Id { get; set; } // Primary key for the course

        [Required]
        public string CourseName { get; set; } // Name of the course

        [Required]
        public string Description { get; set; } // Detailed description of the course

        public string ? ThumbnailUrl { get; set; } // URL for a course thumbnail image

        public string ? Status { get; set; } // Status of the course (e.g., Active, Archived)

        public DateTime CreatedAt { get; set; } = DateTime.Now; // Date when the course was created

        // Navigation Properties
        public UserModel? Creator { get; set; } // User who created the course

        [Required]
        public string CreatorId { get; set; } // Updated to match UserModel primary key type

        public Guid CategoryId { get; set; } // Added CategoryId property

        public CategoryModel? Category { get; set; } // Added Category navigation property

        public ICollection<ClassModel>? Classes { get; set; }
    }
}
