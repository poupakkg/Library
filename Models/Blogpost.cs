using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models
{
    public class Blogpost
    {
        [Key]
        public int BlogId { get; set; }
        [Required(ErrorMessage ="Please write the subject for your post")]
        [MaxLength(50)]
        public string Subject { get; set; }
        [Required(ErrorMessage = "System can not accept empty post")]
        [MaxLength(200)]
        public string Text { get; set; }
        public DateTime Posted { get; set; }
    }
}
