using System;
using System.ComponentModel.DataAnnotations;

namespace BackendApp.Models
{
	public class CategoryDTO : CategoryModel
	{
		public string name { get; set; }
		public string description { get; set; }
        public string ? ImageUrl {get ; set;}

  public  CategoryModel createCategoryDto(CategoryDTO category){
            // create category
            return new CategoryModel { 
                Name = category.name,
                Description = category.description,
                ImageUrl = category.ImageUrl
                // courses = (ICollection<CourseModel>)category.courses,
                // CreatedTimestamp = category.CreatedTimestamp
            };
    }
}
 
 public class CategoryCreateDTO {
		public string name { get; set; }
		public string description { get; set; }
        public Guid  courseId { get; set; }

 }

}

