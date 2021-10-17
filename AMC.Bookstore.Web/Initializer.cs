using System;
using System.Collections.Generic;
using AMC.Bookstore.DataAccess.DatabaseContext;
using AMC.Bookstore.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AMC.Bookstore.Web
{
    public class Initializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = new BookstoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<BookstoreDbContext>>());

            var books = new List<BookDto>
            {
                new BookDto
                {
                    Id = 1,
                    Title = "Book 1",
                    Description = "A great book",
                    PublishDate = DateTime.Now,
                    CoverImageUrl = "https://m.media-amazon.com/images/I/41gr3r3FSWL._SY346_.jpg",
                    AuthorId = 1,
                    CategoryId = 1
                },
                new BookDto
                {
                    Id = 2,
                    Title = "Book 2",
                    Description = "A great book",
                    PublishDate = DateTime.Now,
                    CoverImageUrl = "https://images-na.ssl-images-amazon.com/images/I/51OYR4cjtfL._SY291_BO1,204,203,200_QL40_FMwebp_.jpg",
                    AuthorId = 2,
                    CategoryId = 2
                },
                new BookDto
                {
                    Id = 3,
                    Title = "Book 3",
                    Description = "A great book",
                    PublishDate = DateTime.Now,
                    CoverImageUrl = "https://images-na.ssl-images-amazon.com/images/I/51G2Y+mbUpL._SY344_BO1,204,203,200_.jpg",
                    AuthorId = 2,
                    CategoryId = 3
                }
            };

            var authors = new List<AuthorDto>
            {
                new AuthorDto
                {
                    Id = 1,
                    FirstName = "Kevin",
                    LastName = "Off",
                    HeadshotUrl = "https://media-exp1.licdn.com/dms/image/C4E03AQG-nGM1KlPPkQ/profile-displayphoto-shrink_200_200/0/1516535369221?e=1640217600&v=beta&t=urlyXU2RdigohMPps8lCHau8n9wROpZTZ0ayfRMVz2s"
                },
                new AuthorDto
                {
                    Id = 2,
                    FirstName = "Bob",
                    LastName = "Smith",
                    HeadshotUrl = "https://media.istockphoto.com/photos/put-more-in-get-more-out-picture-id1291318636?s=612x612"
                },
                new AuthorDto
                {
                    Id = 3,
                    FirstName = "Sam",
                    LastName = "Amazing",
                    HeadshotUrl = "https://media.istockphoto.com/photos/learn-to-love-yourself-first-picture-id1291208214?s=612x612"
                }
            };

            var categories = new List<CategoryDto>
            {
                new CategoryDto
                {
                    Id = 1,
                    Name = "Horror"
                },
                new CategoryDto
                {
                    Id = 2,
                    Name = "Romance"
                },
                new CategoryDto
                {
                    Id = 3,
                    Name = "Action"
                }
            };

            var reviews = new List<ReviewDto>
            {
                new ReviewDto
                {
                    Id = 1,
                    Username = "SomeGuy1",
                    Content = "SomeGuy1 says its great",
                    Rating = 5,
                    BookId = 1,
                    PublishDate = DateTime.Now
                },
                new ReviewDto
                {
                    Id = 2,
                    Username = "SomeGuy2",
                    Content = "SomeGuy1 says its great",
                    Rating = 6,
                    BookId = 1,
                    PublishDate = DateTime.Now
                },
                new ReviewDto
                {
                    Id = 3,
                    Username = "SomeGuy3",
                    Content = "SomeGuy1 says its great",
                    Rating = 4,
                    BookId = 2,
                    PublishDate = DateTime.Now
                },
                new ReviewDto
                {
                    Id = 4,
                    Username = "SomeGuy4",
                    Content = "SomeGuy1 says its great",
                    Rating = 5,
                    BookId = 2,
                    PublishDate = DateTime.Now
                },
                new ReviewDto
                {
                    Id = 5,
                    Username = "SomeGuy5",
                    Content = "SomeGuy1 says its great",
                    Rating = 8,
                    BookId = 3,
                    PublishDate = DateTime.Now
                },
                new ReviewDto
                {
                    Id = 6,
                    Username = "SomeGuy6",
                    Content = "SomeGuy123 says its great",
                    Rating = 2,
                    BookId = 3,
                    PublishDate = DateTime.Now
                }
            };

            context.Books.AddRange(books);
            context.Authors.AddRange(authors);
            context.Categories.AddRange(categories);
            context.Reviews.AddRange(reviews);

            context.SaveChanges();
        }
    }
}