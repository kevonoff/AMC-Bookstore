using System.Collections.Generic;
using System.Linq;
using AMC.Bookstore.DataAccess.Repositories.Interfaces;
using AMC.Bookstore.Models;
using AMC.Bookstore.Models.Core;
using AMC.Bookstore.Models.Interfaces;
using AMC.Bookstore.Services.Interfaces;
using AMC.Bookstore.Services.Extensions;
using System.Threading.Tasks;
using AMC.Bookstore.DataAccess.Models;

namespace AMC.Bookstore.Services
{
    public class BookstoreService : IBookstoreService
    {
        private readonly IBookstoreRepository bookstoreRepo;
        private readonly IResourceBuilder resourceBuilder;
        private readonly ILinkBuilder linkBuilder;

        public BookstoreService(
            IBookstoreRepository bookstoreRepo, 
            IResourceBuilder resourceBuilder,
            ILinkBuilder linkBuilder)
        {
            this.bookstoreRepo = bookstoreRepo;
            this.resourceBuilder = resourceBuilder;
            this.linkBuilder = linkBuilder;
        }

        public Book GetBookById(int id)
        {
            return bookstoreRepo.GetBooks()
                .Where(b => b.Id == id)
                .Select(b => resourceBuilder.CreateBookResource(b))
                .SingleOrDefault();
        }

        public Author GetAuthorById(int id)
        {
            return bookstoreRepo.GetAuthors()
                .Where(a => a.Id == id)
                .Select(a => resourceBuilder.CreateAuthorResource(a))
                .SingleOrDefault();
        }

        public Category GetCategoryById(int id)
        {
            return bookstoreRepo.GetCategories()
                .Where(c => c.Id == id)
                .Select(c => resourceBuilder.CreateCategoryResource(c))
                .SingleOrDefault();
        }

        public Review GetReviewById(int id)
        {
            return bookstoreRepo.GetReviews()
                .Where(r => r.Id == id)
                .Select(r => resourceBuilder.CreateReviewResource(r))
                .SingleOrDefault();
        }

        public async Task<ILinkedResourceCollection<Book>> GetBooksAsync(int pageNumber, int resultsPerPage)
        {
            return await bookstoreRepo.GetBooks()
                .PaginateAsync<BookDto, Book>(
                    b => b.PublishDate, 
                    pageNumber, 
                    resultsPerPage, 
                    resourceBuilder
                );
        }

        public async Task<ILinkedResourceCollection<Author>> GetAuthorsAsync(int pageNumber, int resultsPerPage)
        {
            return await bookstoreRepo.GetAuthors()
                .PaginateAsync<AuthorDto, Author>(
                    b => b.LastName, 
                    pageNumber, 
                    resultsPerPage, 
                    resourceBuilder
                );
        }

        public async Task<ILinkedResourceCollection<Category>> GetCategoriesAsync(int pageNumber, int resultsPerPage)
        {
            return await bookstoreRepo.GetCategories()
                .PaginateAsync<CategoryDto, Category>(
                    b => b.Name, 
                    pageNumber, 
                    resultsPerPage, 
                    resourceBuilder
                );
        }

        public async Task<ILinkedResourceCollection<Review>> GetReviewsAsync(int pageNumber, int resultsPerPage)
        {
            return await bookstoreRepo.GetReviews()
                .PaginateAsync<ReviewDto, Review>(
                    b => b.PublishDate, 
                    pageNumber, 
                    resultsPerPage, 
                    resourceBuilder
                );
        }

        public async Task<ILinkedResourceCollection<Review>> GetReviewsByBookIdAsync(int bookId, int pageNumber, int resultsPerPage)
        {

            return await bookstoreRepo.GetReviews()
                .Where(r => r.BookId == bookId)
                .PaginateAsync<ReviewDto, Review>(
                    b => b.PublishDate, 
                    pageNumber, 
                    resultsPerPage, 
                    resourceBuilder
                );
        }

        public async Task<ILinkedResourceCollection<Book>> GetBooksByCategoryIdAsync(int categoryId, int pageNumber, int resultsPerPage)
        {
            return await bookstoreRepo.GetBooks()
                .Where(r => r.CategoryId == categoryId)
                .PaginateAsync<BookDto, Book>(
                    b => b.PublishDate, 
                    pageNumber, 
                    resultsPerPage, 
                    resourceBuilder
                );
        }

        public async Task<ILinkedResourceCollection<Author>> GetAuthorsByCategoryIdAsync(int categoryId, int pageNumber, int resultsPerPage)
        {
            return await bookstoreRepo.GetAuthors()
                .Join(
                    bookstoreRepo.GetBooks(), 
                    author => author.Id, 
                    book => book.AuthorId, 
                    (author, book) => new { Author = author, CategoryId = book.CategoryId})
                .Where(t => t.CategoryId == categoryId)
                .Select(t => t.Author)
                .PaginateAsync<AuthorDto, Author>(
                    b => b.LastName, 
                    pageNumber, 
                    resultsPerPage, 
                    resourceBuilder
                );
        }

        public async Task<ILinkedResourceCollection<Review>> GetReviewsByCategoryIdAsync(int categoryId, int pageNumber, int resultsPerPage)
        {
            return await bookstoreRepo.GetReviews()
                .Join(
                    bookstoreRepo.GetBooks(), 
                    review => review.BookId, 
                    book => book.Id, 
                    (review, book) => new { Review = review, CategoryId = book.CategoryId})
                .Where(t => t.CategoryId == categoryId)
                .Select(t => t.Review)
                .PaginateAsync<ReviewDto, Review>(
                    b => b.PublishDate,
                    pageNumber,
                    resultsPerPage,
                    resourceBuilder
                );
        }

        public async Task<ILinkedResourceCollection<Category>> GetCategoriesByAuthorIdAsync(int authorId, int pageNumber, int resultsPerPage)
        {
            return await bookstoreRepo.GetCategories()
                .Join(
                    bookstoreRepo.GetBooks(), 
                    category => category.Id, 
                    book => book.CategoryId, 
                    (category, book) => new { Category = category, AuthorId = book.AuthorId})
                .Where(t => t.AuthorId == authorId)
                .Select(r => r.Category)
                .PaginateAsync<CategoryDto, Category>(
                    b => b.Name,
                    pageNumber,
                    resultsPerPage,
                    resourceBuilder
                );
        }

        public async Task<ILinkedResourceCollection<Review>> GetReviewsByAuthorIdAsync(int authorId, int pageNumber, int resultsPerPage)
        {
            return await bookstoreRepo.GetReviews()
                .Join(
                    bookstoreRepo.GetBooks(), 
                    review => review.BookId, 
                    book => book.Id, 
                    (review, book) => new { Review = review, AuthorId = book.AuthorId})
                .Where(t => t.AuthorId == authorId)
                .Select(r => r.Review)
                .PaginateAsync<ReviewDto, Review>(
                    r => r.PublishDate,
                    pageNumber,
                    resultsPerPage,
                    resourceBuilder
                );
        }

        public async Task<ILinkedResourceCollection<Book>> GetBooksByAuthorIdAsync(int authorId, int pageNumber, int resultsPerPage)
        {
            return await bookstoreRepo.GetBooks()
                .Where(r => r.AuthorId == authorId)
                .PaginateAsync<BookDto, Book>(
                    b => b.PublishDate,
                    pageNumber,
                    resultsPerPage,
                    resourceBuilder
                );
        }

        public async Task<ILinkedResourceCollection<Book>> GetBooksByCategoryIdAndAuthorIdAsync(int categoryId, int authorId, int pageNumber, int resultsPerPage)
        {
            return await bookstoreRepo.GetBooks()
                .Where(r => r.CategoryId == categoryId && r.AuthorId == authorId)
                .PaginateAsync<BookDto, Book>(
                    b => b.PublishDate,
                    pageNumber,
                    resultsPerPage,
                    resourceBuilder
                );
        }

        public ILinkedResourceCollection<ILinkedResource> GetHomePageListing()
        {
            var result = new BookstoreResourceCollection<ILinkedResource>();
            result.Links = resourceBuilder.GetLinkBuilder().BuildBookstoreHomePageLinks();

            return result;
        }
    }
}
