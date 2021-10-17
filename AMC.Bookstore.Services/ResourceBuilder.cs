using AMC.Bookstore.DataAccess.Models;
using AMC.Bookstore.Models.Core;
using AMC.Bookstore.Models.Interfaces;
using AMC.Bookstore.Services.Interfaces;

namespace AMC.Bookstore.Services
{
    public class ResourceBuilder : IResourceBuilder
    {
        private readonly ILinkBuilder linkBuilder;

        public ResourceBuilder(ILinkBuilder builder)
        {
            linkBuilder = builder;
        }

        public ILinkBuilder GetLinkBuilder()
        {
            return linkBuilder;
        }

        public IBookstoreResource CreateResource(IBookstoreDataModel model)
        {
            switch(model)
            {
                case BookDto book:
                    return CreateBookResource(book);
                case AuthorDto author:
                    return CreateAuthorResource(author);
                case CategoryDto category:
                    return CreateCategoryResource(category);
                case ReviewDto review:
                    return CreateReviewResource(review);
            }
            return null;
        }

        public Book CreateBookResource(BookDto book)
        {
            if (book == null)
            {
                return null;
            }

            var resource = new Book
            {
                Id = book.Id,
                Title = book.Title,
                Description = book.Description,
                PublishDate = book.PublishDate,
                CoverImageUrl = book.CoverImageUrl,
                AuthorId = book.AuthorId,
                CategoryId = book.CategoryId
            };
            resource.Links = linkBuilder.BuildLinks(resource);
            return resource;
        }

        public Author CreateAuthorResource(AuthorDto author)
        {
            if (author == null)
            {
                return null;
            }

            var resource = new Author
            {
                Id = author.Id,
                FirstName = author.FirstName,
                LastName = author.LastName,
                Headshot = author.HeadshotUrl
            };
            resource.Links = linkBuilder.BuildLinks(resource);
            return resource;
        }

        public Category CreateCategoryResource(CategoryDto category)
        {
            if (category == null)
            {
                return null;
            }
            
            var resource = new Category
            {
                Id = category.Id,
                Name = category.Name,
            };
            resource.Links = linkBuilder.BuildLinks(resource);
            return resource;
        }

        public Review CreateReviewResource(ReviewDto review)
        {
            if (review == null)
            {
                return null;
            }

            var resource = new Review
            {
                Id = review.Id,
                Username = review.Username,
                Content = review.Content,
                Rating = review.Rating,
                BookId = review.BookId,
                PublishDate = review.PublishDate
            };
            resource.Links = linkBuilder.BuildLinks(resource);
            return resource;
        }

        
    }
}