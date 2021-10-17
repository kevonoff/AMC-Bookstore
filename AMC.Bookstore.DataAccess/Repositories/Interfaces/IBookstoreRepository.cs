using System.Collections.Generic;
using System.Linq;
using AMC.Bookstore.DataAccess.Models;

namespace AMC.Bookstore.DataAccess.Repositories.Interfaces
{
    public interface IBookstoreRepository
    {
        IQueryable<BookDto> GetBooks();
        IQueryable<AuthorDto> GetAuthors();
        IQueryable<ReviewDto> GetReviews();
        IQueryable<CategoryDto> GetCategories();
    }
}