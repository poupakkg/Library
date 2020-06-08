using Library.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Controllers.Data
{
    public class LibraryContext : IdentityDbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext>options) : base(options)
        {
              
        }
        public DbSet<Booklist> Booklist { get; set;}

        public DbSet<Library.Models.Blogpost> Blogpost { get; set; }

        public DbSet<Library.Models.User> User { get; set; }
      
    }
}
