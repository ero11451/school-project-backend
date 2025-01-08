using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BackendApp.Models;

namespace BackendApp.Models
{
    public class CourseDTO
    {
        public Guid ? Id {get;set;}
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
        // If additional details about category are needed, use a simpler version
        public string? CategoryName { get; set; }

        public string? TeacherId { get; set; }
        public TeacherDTO? Teacher { get; set; }

        public string? Question { get; set; }
        public List<OptionDTO>? Options { get; set; }
        public DateTime CreatedTimestamp { get; set; } = DateTime.UtcNow;

        public class TeacherDTO
        {
            public string UserName { get; set; }
            public string Email { get; set; }
            public string? ImgUrl { get; set; }
        }

        public class OptionDTO
        {
            public string OptionText { get; set; }
            public bool IsCorrect { get; set; }
        }
    }


public class CourseMapper
{
    public static CourseModel MapToCourseModel(CourseDTO courseDTO)
    {
        return new CourseModel
        {
            Id = (Guid)courseDTO.Id,
            Title = courseDTO.Title,
            Content = courseDTO.Content,
            Summary = courseDTO.Summary,
            ImgUrl = courseDTO.ImgUrl,
            Code = courseDTO.Code,
            VideoUrl = courseDTO.VideoUrl,
            Status = courseDTO.Status,
            CategoryId = courseDTO.CategoryId,
            TeacherId = courseDTO.TeacherId,
            Question = courseDTO.Question,
            CreatedTimestamp = courseDTO.CreatedTimestamp,
            Options = courseDTO.Options?.ConvertAll(o => new OptionsModel
            {
                OptionText = o.OptionText,
                IsCorrect = o.IsCorrect
            })
        };
    }
}


}