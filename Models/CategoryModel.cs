using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackendApp.Models
{
    public class CategoryModel
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Name { get; set; }
        public string Description { get; set; }
        public string ? ImageUrl { get; set;}

        // Foreign key for User (Teacher)
        public string? TeacherId { get; set; }

        // Navigation property for Teacher
        [ForeignKey("TeacherId")]
        public UserModel? Teacher { get; set; }

        // One-to-many relationship with CourseModel
        public ICollection<CourseModel> Courses { get; set; } = new List<CourseModel>();

        public DateTime CreatedTimestamp { get; set; }

       
    }
}
