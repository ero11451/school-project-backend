using BackendApp.Models;

namespace BackendApp.Models
{
    public class PostModel
    {
        public int id { get; set; }

        public string title { get; set; } = null;

        public string content { get; set; } = null;

        public bool Paid { get; set; }

        public string ImgUrl { get; set; }

        public string VideoUrl { get; set; }

        public string Status { get; set; }

        public int? Test { get; set;}
        public TestMode TestMode { get; set; }

        public int? CategoryId { get; set; }
        
        public CategoryModel Category { get; set; }

        public int? LocationId { get; set; }

        public LocationModel Location { get; set; }

        public int? TeacherId { get; set; }

        public UserModel Teacher { get; set; }
    }

 
}
