using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace  BackendApp.Models
{
    public class LocationModel
    {
        public int id { get; set; }
        [Required]
        public string location { get; set; } = null;

    }
}
