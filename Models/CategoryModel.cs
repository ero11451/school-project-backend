using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackendApp.Models
{
    public class CategoryModel
    {
        [Key]
        public Guid Id { get; set; } // Primary key for the category

        [Required]
        [MaxLength(100)]
        public string CategoryName { get; set; } // Name of the category (e.g., "Programming", "Design", etc.)

        public string Description { get; set; } // A brief description of the category

        public DateTime CreatedTimestamp { get; set; } = DateTime.UtcNow; // Set to  UTC for consistency

        public Guid CategoryId { get; set; } 
        // Navigation Property
        public ICollection<CourseModel> Courses { get; set; } // List of courses related to this category
    }
}
