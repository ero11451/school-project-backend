using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackendApp.Models
{
    public class TestModel
    {
        [Key]
        public Guid TestId { get; set; }

        [Required]
        public Guid ClassId { get; set; }

        [Required]
        public string Question { get; set; }

        public ICollection<TestOptionModel> Options { get; set; }

        // Navigation Property
        public ClassModel Class { get; set; }
    }

    public class TestOptionModel
    {
        [Key]
        public Guid OptionId { get; set; }

        [Required]
        public Guid TestId { get; set; }

        [Required]
        public string OptionText { get; set; } // Text of the option

        public bool IsCorrect { get; set; } // True if this option is part of the correct answer

        // Navigation Property
        public TestModel Test { get; set; }
    }
}
