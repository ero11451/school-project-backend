using System.ComponentModel.DataAnnotations;


    public class CreateCategoryRequest
    {
        [Required]
        public string CategoryName { get; set; }
        [Required]
        public string Description { get; set; }
    }


    public class UpdateCategoryRequest
    {
        public string CategoryName { get; set; }
        public string Description { get; set; }
    }
