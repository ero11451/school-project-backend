public class BlogRequestDTO
{
   
        public required string title { get; set; } = string.Empty;

        public required string content { get; set; } = string.Empty;

        public string? imgUrl { get; set; }

        public string? videoUrl { get; set; }

        public string? Code { get; set; }

        public string? summary { get; set; }

        public string? Status { get; set; }

        public Guid? CategoryId { get; set; }
}