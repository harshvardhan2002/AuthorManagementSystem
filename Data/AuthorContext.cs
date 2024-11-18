using AuthorWebApiProject.Models;
using Microsoft.EntityFrameworkCore;

namespace AuthorWebApiProject.Data
{
    public class AuthorContext:DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<AuthorDetail> AuthorDetails { get; set; }
        public DbSet<Book> Books { get; set; }

        public AuthorContext(DbContextOptions<AuthorContext> options) : base(options)
        {

        }
    }
}
