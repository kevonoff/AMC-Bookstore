using System.Threading.Tasks;
using AMC.Bookstore.Models.Core;
using AMC.Bookstore.Models.Interfaces;

namespace AMC.Bookstore.Services.Interfaces
{
    public interface IBookstoreService
    {
        Book GetBookById(int id);

        Author GetAuthorById(int id);

        Category GetCategoryById(int id);

        Review GetReviewById(int id);

        ILinkedResourceCollection<ILinkedResource> GetHomePageListing();

        Task<ILinkedResourceCollection<Book>> GetBooksAsync(int pageNumber, int resultsPerPage);

        Task<ILinkedResourceCollection<Author>> GetAuthorsAsync(int pageNumber, int resultsPerPage);

        Task<ILinkedResourceCollection<Category>> GetCategoriesAsync(int pageNumber, int resultsPerPage);

        Task<ILinkedResourceCollection<Review>> GetReviewsAsync(int pageNumber, int resultsPerPage);

        Task<ILinkedResourceCollection<Book>> GetBooksByCategoryIdAsync(int categoryId, int pageNumber, int resultsPerPage);

        Task<ILinkedResourceCollection<Book>> GetBooksByCategoryIdAndAuthorIdAsync(int categoryId, int authorId, int pageNumber, int resultsPerPage);

        Task<ILinkedResourceCollection<Author>> GetAuthorsByCategoryIdAsync(int categoryId, int pageNumber, int resultsPerPage);

        Task<ILinkedResourceCollection<Review>> GetReviewsByCategoryIdAsync(int categoryId, int pageNumber, int resultsPerPage);

        Task<ILinkedResourceCollection<Review>> GetReviewsByBookIdAsync(int bookId, int pageNumber, int resultsPerPage);

        Task<ILinkedResourceCollection<Category>> GetCategoriesByAuthorIdAsync(int authorId, int pageNumber, int resultsPerPage);

        Task<ILinkedResourceCollection<Review>> GetReviewsByAuthorIdAsync(int authorId, int pageNumber, int resultsPerPage);
        
        Task<ILinkedResourceCollection<Book>> GetBooksByAuthorIdAsync(int authorId, int pageNumber, int resultsPerPage);

    }
}
