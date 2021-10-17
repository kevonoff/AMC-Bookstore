using System.Collections.Generic;
using System.Linq;
using AMC.Bookstore.DataAccess.DatabaseContext;
using AMC.Bookstore.DataAccess.Models;
using AMC.Bookstore.DataAccess.Repositories.Interfaces;

namespace AMC.Bookstore.DataAccess.Repositories
{
    public class BookstoreRepository : IBookstoreRepository
    {
        private readonly BookstoreDbContext dbContext;
        
        public BookstoreRepository(BookstoreDbContext context)
        {
            dbContext = context;
        }

        public IQueryable<AuthorDto> GetAuthors()
        {
            return dbContext.Authors;
        }

        public IQueryable<BookDto> GetBooks()
        {
            return dbContext.Books;
        }

        public IQueryable<CategoryDto> GetCategories()
        {
            return dbContext.Categories;
        }

        public IQueryable<ReviewDto> GetReviews()
        {
            return dbContext.Reviews;
        }
    }
}