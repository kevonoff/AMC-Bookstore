using System.Threading.Tasks;
using AMC.Bookstore.Models.Core;
using AMC.Bookstore.Models.Interfaces;
using AMC.Bookstore.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AMC.Bookstore.Web.Controllers
{
    [ApiController]
    [Route("")]
    public class BookstoreController : ControllerBase
    {

        private readonly ILogger<BookstoreController> _logger;
        private readonly IBookstoreService bookstoreService;

        public BookstoreController(
            ILogger<BookstoreController> logger, 
            IBookstoreService service)
        {
            _logger = logger;
            bookstoreService = service;
        }

        [HttpGet("")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ILinkedResourceCollection<Book>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Home(int pageNumber, int resultsPerPage)
        {
            var books = bookstoreService.GetHomePageListing();
            return Ok(books);
        }

        [HttpGet("book")]
        [HttpGet("books")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ILinkedResourceCollection<Book>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetBooks(int pageNumber, int resultsPerPage)
        {
            var books = await bookstoreService.GetBooksAsync(pageNumber, resultsPerPage);
            if (books == null)
            {
                return NotFound();
            }

            return Ok(books);
        }

        [HttpGet("category")]
        [HttpGet("categories")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ILinkedResourceCollection<Category>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetCategories(int pageNumber, int resultsPerPage)
        {
            var categories = await bookstoreService.GetCategoriesAsync(pageNumber, resultsPerPage);
            if (categories == null)
            {
                return NotFound();
            }

            return Ok(categories);
        }

        [HttpGet("review")]
        [HttpGet("reviews")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ILinkedResourceCollection<Review>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetReviews(int pageNumber, int resultsPerPage)
        {
            var reviews = await bookstoreService.GetReviewsAsync(pageNumber, resultsPerPage);
            if (reviews == null)
            {
                return NotFound();
            }

            return Ok(reviews);
        }

        [HttpGet("author")]
        [HttpGet("authors")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ILinkedResourceCollection<Author>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAuthors(int pageNumber, int resultsPerPage)
        {
            var authors = await bookstoreService.GetAuthorsAsync(pageNumber, resultsPerPage);
            if (authors == null)
            {
                return NotFound();
            }

            return Ok(authors);
        }

        [HttpGet("book/{bookId}")]
        [HttpGet("books/{bookId}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Book))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetBook(int bookId)
        {
            var book = bookstoreService.GetBookById(bookId);
            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        [HttpGet("review/{reviewId}")]
        [HttpGet("reviews/{reviewId}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Review))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetReview(int reviewId)
        {
            var review = bookstoreService.GetReviewById(reviewId);
            if (review == null)
            {
                return NotFound();
            }

            return Ok(review);
        }

        [HttpGet("author/{authorId}")]
        [HttpGet("authors/{authorId}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Author))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetAuthor(int authorId)
        {
            var author = bookstoreService.GetAuthorById(authorId);
            if (author == null)
            {
                return NotFound();
            }

            return Ok(author);
        }

        [HttpGet("category/{categoryId}")]
        [HttpGet("categories/{categoryId}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Category))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetCategory(int categoryId)
        {
            var category = bookstoreService.GetCategoryById(categoryId);
            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        [HttpGet("book/{bookId}/reviews")]
        [HttpGet("books/{bookId}/reviews")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ILinkedResourceCollection<Review>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetReviewsForBook(int bookId, int pageNumber, int resultsPerPage)
        {
            var reviews = await bookstoreService.GetReviewsByBookIdAsync(bookId, pageNumber, resultsPerPage);

            if (reviews == null)
            {
                return NotFound();
            }

            return Ok(reviews);
        }

        [HttpGet("category/{categoryId}/books")]
        [HttpGet("categories/{categoryId}/books")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ILinkedResourceCollection<Book>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetBooksForCategory(int categoryId, int pageNumber, int resultsPerPage)
        {
            var books = await bookstoreService.GetBooksByCategoryIdAsync(categoryId, pageNumber, resultsPerPage);

            if (books == null)
            {
                return NotFound();
            }

            return Ok(books);
        }

        [HttpGet("category/{categoryId}/authors")]
        [HttpGet("categories/{categoryId}/authors")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ILinkedResourceCollection<Author>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAuthorsForCategory(int categoryId, int pageNumber, int resultsPerPage)
        {
            var authors = await bookstoreService.GetAuthorsByCategoryIdAsync(categoryId, pageNumber, resultsPerPage);

            if (authors == null)
            {
                return NotFound();
            }

            return Ok(authors);
        }

        [HttpGet("category/{categoryId}/reviews")]
        [HttpGet("categories/{categoryId}/reviews")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ILinkedResourceCollection<Review>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetReviewsForCategory(int categoryId, int pageNumber, int resultsPerPage)
        {
            var reviews = await bookstoreService.GetReviewsByCategoryIdAsync(categoryId, pageNumber, resultsPerPage);

            if (reviews == null)
            {
                return NotFound();
            }

            return Ok(reviews);
        }

        [HttpGet("author/{authorId}/books")]
        [HttpGet("authors/{authorId}/books")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ILinkedResourceCollection<Book>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetBooksForAuthor(int authorId, int pageNumber, int resultsPerPage)
        {
            var books = await bookstoreService.GetBooksByAuthorIdAsync(authorId, pageNumber, resultsPerPage);

            if (books == null)
            {
                return NotFound();
            }

            return Ok(books);
        }

        [HttpGet("author/{authorId}/reviews")]
        [HttpGet("authors/{authorId}/reviews")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ILinkedResourceCollection<Review>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetReviewsForAuthor(int authorId, int pageNumber, int resultsPerPage)
        {
            var reviews = await bookstoreService.GetReviewsByAuthorIdAsync(authorId, pageNumber, resultsPerPage);

            if (reviews == null)
            {
                return NotFound();
            }

            return Ok(reviews);
        }

        [HttpGet("author/{authorId}/categories")]
        [HttpGet("authors/{authorId}/categories")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ILinkedResourceCollection<Category>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetCategoriesForAuthor(int authorId, int pageNumber, int resultsPerPage)
        {
            var category = await bookstoreService.GetCategoriesByAuthorIdAsync(authorId, pageNumber, resultsPerPage);

            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        [HttpGet("category/{categoryId}/author/{authorId}/books")]
        [HttpGet("categories/{categoryId}/authors/{authorId}/books")]
        [HttpGet("category/{categoryId}/authors/{authorId}/books")]
        [HttpGet("categories/{categoryId}/author/{authorId}/books")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ILinkedResourceCollection<Book>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetBooksForCategoryAndAuthor(int categoryId, int authorId, int pageNumber, int resultsPerPage)
        {
            var books = await bookstoreService.GetBooksByCategoryIdAndAuthorIdAsync(categoryId, authorId, pageNumber, resultsPerPage);

            if (books == null)
            {
                return NotFound();
            }

            return Ok(books);
        }
        
    }
}
