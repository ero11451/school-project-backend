using System.ComponentModel.DataAnnotations;


public class ClassResponse
{
    public Guid Id { get; set; } // ID of the class
    public string CourseName { get; set; } // Name of the associated course
    public string InstructorName { get; set; } // Name of the instructor
    public Guid CourseId { get; set; } // ID of the associated course
    public Guid InstructorId { get; set; } // ID of the instructor
    public string ClassName { get; set; } // Name of the class
    public string Title { get; set; } // Title of the class
    public string Content { get; set; } // Content of the class
    public string Summary { get; set; } // Summary of the class
    public string ImgUrl { get; set; } // Image URL
    public string Code { get; set; } // Code snippet
    public string VideoUrl { get; set; } // Video URL
    public List<TestRequest> Tests { get; set; } // List of tests for the class
}


public class ClassRequest
{
    [Required]
    public Guid CourseId { get; set; } // ID of the associated course

    [Required]
    public Guid InstructorId { get; set; } // ID of the instructor

    [Required]
    public string ClassName { get; set; } // Name of the class

    // Optional Properties
    public string Title { get; set; }
    public string Content { get; set; }
    public string Summary { get; set; }
    public string ImgUrl { get; set; }
    public string Code { get; set; }
    public string VideoUrl { get; set; }
    public List<TestRequest> Tests { get; set; } // List of tests for the class
}




 public class TestRequest
    {
        [Required]
        public string Question { get; set; } // Question for the test

        [Required]
        public List<TestOptionRequest> Options { get; set; } // List of options for the test
    }

    public class TestOptionRequest
    {
        [Required]
        public string OptionText { get; set; } // Option text
        public bool IsCorrect { get; set; } // Indicates if this option is correct
    }

