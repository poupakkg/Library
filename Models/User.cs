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
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        public string FirstName { get; set; }
        [Required]
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        public string Lastname { get; set; }
        [Required(ErrorMessage = "Please use the valid email address with @")]
        public string Email { get; set; }
        [Required]
        [MaxLength(15)]
        public string Password { get; set; }
    }
}
