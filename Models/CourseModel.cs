using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BackendApp.Models
{
    public class CourseModel
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        
        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
        public string? Summary { get; set; }
        public string? ImgUrl { get; set; }
        public string? Code { get; set; }
        public string? VideoUrl { get; set; }
        public string? Status { get; set; }

        // Foreign key to CategoryModel
        public Guid CategoryId { get; set; }
        
        // Navigation property for CategoryModel
        [ForeignKey("CategoryId")]
        public CategoryModel? Category { get; set; }

        // Foreign key for User (Teacher)
        public string? TeacherId { get; set; }

        // Navigation property for Teacher
        [ForeignKey("TeacherId")]
        public UserModel? Teacher { get; set; }

        public string? Question { get; set; }
        
        // Optional foreign key reference for Options
        public Guid? OptionId { get; set; }
        
        // One-to-many relationship with OptionsModel
         [JsonIgnore]
        public List<OptionsModel>? Options { get; set; } = new List<OptionsModel>();

        // Timestamp for when the course was created
        public DateTime CreatedTimestamp { get; set; } = DateTime.UtcNow;
    }

 public class OptionsModel
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    public string OptionText { get; set; }
    public bool IsCorrect { get; set; }

    // Foreign key to CourseModel
    public Guid CourseId { get; set; }
    [JsonIgnore]
    public CourseModel? Course { get; set; } // Navigation property to CourseModel
}


}
