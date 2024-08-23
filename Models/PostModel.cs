using System.ComponentModel.DataAnnotations.Schema;

namespace BackendApp.Models
{
    public class PostModel
    {
        public int Id { get; set; }

        public string Title { get; set; } = null;

        public string Content { get; set; } = null;

        public string? ImgUrl { get; set; }

        public string? VideoUrl { get; set; }

        public string? Code { get; set; }

        public string? Summary { get; set; }

        public string? Status { get; set; }

        public int? CategoryId { get; set; }
        public CategoryModel ? Category { get; set; }

        // public int? LocationId { get; set; }
        // public LocationModel Location { get; set; }

        // public int? TeacherId { get; set; }
        // public UserModel Teacher { get; set; }

        public string? Question { get; set; }

        // Cascade delete for Options
        // [InverseProperty("PostModel")]
        public List<TestOptions> Options { get; set; } = new List<TestOptions>();
    }

    public class TestOptions
    {
        public int id { get; set; }
        public string Option { get; set; }
        public bool IsCorrect { get; set; }

        // Foreign key back to PostModel
        // public int PostModelId { get; set; }
        // public PostModel PostModel { get; set; }
    }
}
