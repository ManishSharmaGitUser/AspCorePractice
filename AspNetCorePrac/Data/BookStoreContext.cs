using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCorePrac.Data
{
    public class BookStoreContext :IdentityDbContext
    {
        public BookStoreContext(DbContextOptions<BookStoreContext> options) : base(options)
        {

        }

        public DbSet<Books> Books { get; set; }

        public DbSet<Language> Languages { get; set; }

        public DbSet<BookGallery> BookGallery { get; set; }


        //commented b/c in statup class we passed connection string
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=DESKTOP-LFMLTL8\\SQLEXPRESS;Database=BookStore;Integrated Security=true");
        //    base.OnConfiguring(optionsBuilder);
        //}
    }
}
