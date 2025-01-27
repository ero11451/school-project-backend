using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackendApp.Models
{
    public class ClassModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid CourseId { get; set; }
    
        public string ClassName { get; set; }
        public int DurationMinutes { get; set; }
        public int MaxStudents { get; set; } = 30;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        // public string ? ThumbnailUrl { get; set; } // URL for a course thumbnail image
        // Additional Properties
        public string Title { get; set; } // Title of the class
        public string Content { get; set; } // Detailed content (could be large text or rich content)
        public string Summary { get; set; } // Brief summary of the class
        public string ImgUrl { get; set; } // URL for an image related to the class
        public string Code { get; set; } // Unique code for the class (e.g., for tracking or joining)
        public string ? Status { get; set; } // Status (e.g., Active, Completed, Canceled)
        public string VideoUrl { get; set; } // URL for a related video

        // Navigation Properties
        public CourseModel Course { get; set; }
        public ICollection<TestModel> Tests { get; set; }
    }


   }