namespace BackendApp.Models
{

    public class PostModel
    {
        public int Id { get; set; }

        public string Title { get; set; } = null;

        public string Content { get; set; } = null;

        public string ImgUrl { get; set; }

        public string VideoUrl { get; set; }
       
         public string? Code { get; set; }
         
        public string? Status { get; set; }

        public int? TestId { get; set; }
        public TestModel Test { get; set; }

        public int? CategoryId { get; set; }
        public CategoryModel Category { get; set; }

        public int? LocationId { get; set; }
        public LocationModel Location { get; set; }

        public int? TeacherId { get; set; }
        public UserModel Teacher { get; set; }
    }
}
