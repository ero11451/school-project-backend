using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace  BackendApp.Models
{
    public class CategoryModel
    {
        public int id { get; set; }
        [Required]
        public string category {get;set;}

        
    }
}
