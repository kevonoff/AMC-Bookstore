using AMC.Bookstore.DataAccess.Models;
using AMC.Bookstore.Models.Core;
using AMC.Bookstore.Models.Interfaces;

namespace AMC.Bookstore.Services.Interfaces
{
    public interface IResourceBuilder
    {
        IBookstoreResource CreateResource(IBookstoreDataModel model);

        Book CreateBookResource(BookDto book);

        Author CreateAuthorResource(AuthorDto author);

        Category CreateCategoryResource(CategoryDto category);

        Review CreateReviewResource(ReviewDto review);

        ILinkBuilder GetLinkBuilder();
    }
}