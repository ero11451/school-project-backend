using System.ComponentModel.DataAnnotations.Schema;

namespace BackendApp.Models
{
    public class PostModel
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string title { get; set; } = null;

        public string content { get; set; } = null;

        public string? imgUrl { get; set; }

        public string? videoUrl { get; set; }

        public string? Code { get; set; }

        public string? summary { get; set; }

        public string? Status { get; set; }

        public int? CategoryId { get; set; }
        public CategoryModel ? Category { get; set; }


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
