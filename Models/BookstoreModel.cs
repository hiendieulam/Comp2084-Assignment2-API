using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore_API.Models
{
    public class BookstoreModel : DbContext
    {
        public BookstoreModel(DbContextOptions<BookstoreModel>options) : base(options)
        {
            
        }

        // Reference the Bookstore model for CRUB
        public DbSet<Book> Books { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
    }
}
