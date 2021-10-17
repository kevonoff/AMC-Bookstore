using AMC.Bookstore.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace AMC.Bookstore.DataAccess.DatabaseContext
{
    public class BookstoreDbContext : DbContext
    {
        public BookstoreDbContext(DbContextOptions<BookstoreDbContext> options)
        : base(options) { }
        
        public DbSet<BookDto> Books { get; set; }
        public DbSet<AuthorDto> Authors { get; set; }
        public DbSet<CategoryDto> Categories { get; set; }
        public DbSet<ReviewDto> Reviews { get; set; }
    }
}