using Microsoft.AspNetCore.Identity;

namespace BackendApp.Models
{
    public class UserModel : IdentityUser
    {
        public string? user_name { get; set; }
        public string? Password { get; set; }
        public int? Phone { get; set; }
        public string? Bio { get; set; }
        public string? UserimgUrl { get; set; }

        public Gender? Gender { get; set; }

        public UserType? UserType { get; set; }

        public Status? Status { get; set; }

        public ICollection<CourseModel> Courses { get; set; } = new List<CourseModel>();


        // public required ICollection<Enrollment> ? Courses { get; set; }

        // public ICollection<Enrollment> ? Enrollments { get; set; }
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