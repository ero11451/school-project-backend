using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace BackendApp.Models
{
    public class ContactModel
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        public string FullName { get; set; }
        public string Email { get; set; }
        public string ? Subject { get; set;}
        public string? Message { get; set;}

        public DateTime CreatedTimestamp { get; set; }

       
    }
}
