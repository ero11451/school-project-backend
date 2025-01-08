using System;
using System.ComponentModel.DataAnnotations;

namespace BackendApp.Models
{
    public class CourseCreateDTO
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        public string? Summary { get; set; }
        public string? ImgUrl { get; set; }
        public string? Code { get; set; }
        public string? VideoUrl { get; set; }
        public string? Status { get; set; }

        [Required]
        public Guid CategoryId { get; set; }

        public string? TeacherId { get; set; }
        public string? Question { get; set; }
        
        public List<OptionCreateDTO>? Options { get; set; }

        public DateTime CreatedTimestamp { get; set; } = DateTime.UtcNow;

        public class OptionCreateDTO
        {
            public string OptionText { get; set; }
            public bool IsCorrect { get; set; }
        }
    }


    public static class CourseCreateMapper
{
    public static CourseModel MapToCourseModel(CourseCreateDTO courseCreateDTO)
    {
        return new CourseModel
        {
            Title = courseCreateDTO.Title,
            Content = courseCreateDTO.Content,
            Summary = courseCreateDTO.Summary,
            ImgUrl = courseCreateDTO.ImgUrl,
            Code = courseCreateDTO.Code,
            VideoUrl = courseCreateDTO.VideoUrl,
            Status = courseCreateDTO.Status,
            CategoryId = courseCreateDTO.CategoryId,
            TeacherId = courseCreateDTO.TeacherId,
            Question = courseCreateDTO.Question,
            CreatedTimestamp = courseCreateDTO.CreatedTimestamp,
            Options = courseCreateDTO.Options?.ConvertAll(o => new OptionsModel
            {
                OptionText = o.OptionText,
                IsCorrect = o.IsCorrect
            })
        };
    }
}

}
