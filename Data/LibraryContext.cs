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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booklist>().HasData(
                    new Booklist
                    {
                        Id=1,
                        BookName = "The Essential",
                        Author = "Rumi",
                        Genre = "Poem"
                    },
                     new Booklist
                    {
                    Id=2,
                         BookName = "Anna Karenina",
                         Author = "Leo Tolstoy",
                         Genre = "Romance"
                     },
                    new Booklist
                    {
                        Id = 3,
                        BookName = "The Big Pharmacology",
                        Author = "Rhazes",
                        Genre = "Science"
                    }
                 );
        }

        public DbSet<Library.Models.Blogpost> Blogpost { get; set; }

        public DbSet<Library.Models.User> User { get; set; }
      
    }
}

