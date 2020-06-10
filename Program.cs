using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Controllers.Data;
using Library.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;


namespace Library
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
        public static void User(LibraryContext context, string AdminId)
        {
            if (context.User.Any())
            {
                return;
            }

            context.User.AddRange(
                new User
                {
                    FirstName = "Admin",
                    Email = "admin@example.com",
                    Password="MyAdmin123*",
                    //OwnerID = AdminID
                });
        }
    }
}
