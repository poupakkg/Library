using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models
{
    public class Booklist
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Book Name")]
        //[Required(ErrorMessage ="Book Name is Required")]
        public string BookName { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
    }
}
