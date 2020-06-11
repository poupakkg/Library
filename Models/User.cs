using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Required]       
        public string FirstName { get; set; }
        [Required]        
        public string Lastname { get; set; }
        [Required(ErrorMessage = "Please use the valid email address with @")]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [MaxLength(10)]
        public string Password { get; set; }
       
    }
}
