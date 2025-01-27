using System.ComponentModel.DataAnnotations.Schema;

namespace BackendApp.Models
{
    public class BlogModel
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public required string title { get; set; } = string.Empty;

        public required string content { get; set; } = string.Empty;

        public string? imgUrl { get; set; }

        public string? videoUrl { get; set; }

        public string? Code { get; set; }

        public string? summary { get; set; }

        public string? Status { get; set; }

        public Guid? CategoryId { get; set; }
        public BlogCategoryModel ? Category { get; set; }


    }

    public class BlogCategoryModel
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ? ImgUrl { get; set; }
        public ICollection<BlogModel> Blogs { get; set; }
    }
}
