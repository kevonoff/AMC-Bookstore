using System.Collections.Generic;
using AMC.Bookstore.Models;
using AMC.Bookstore.Models.Core;
using AMC.Bookstore.Models.Interfaces;
using AMC.Bookstore.Services.Interfaces;

namespace AMC.Bookstore.Services
{
    public class BookstoreLinkBuilder : LinkBuilderBase
    {
        public BookstoreLinkBuilder(
            IHttpContextService context) : base(context)
        {
        }

        public override IList<Link> BuildCustomLinks(IBookstoreResource resource)
        {
            var links = new List<Link>
            {
                new Link
                {
                    Href = $"{httpContext.GetScheme()}://{this.httpContext.GetHost()}/{resource.GetType().Name}/{resource.Id}".ToLower(),
                    Rel = "Create",
                    Method = "POST"
                },
                new Link
                {
                    Href = $"{httpContext.GetScheme()}://{this.httpContext.GetHost()}/{resource.GetType().Name}/{resource.Id}".ToLower(),
                    Rel = "Update",
                    Method = "PUT"
                },
                new Link
                {
                    Href = $"{httpContext.GetScheme()}://{this.httpContext.GetHost()}/{resource.GetType().Name}/{resource.Id}".ToLower(),
                    Rel = "Delete",
                    Method = "DELETE"
                }
            };

            return links;
        }

        public override IList<Link> BuildBookstoreHomePageLinks()
        {
            var links = new List<Link>
            {
                new Link
                {
                    Href = $"{httpContext.GetScheme()}://{this.httpContext.GetHost()}/{nameof(Book)}".ToLower(),
                    Rel = "Books",
                    Method = "Get"
                },
                new Link
                {
                    Href = $"{httpContext.GetScheme()}://{this.httpContext.GetHost()}/{nameof(Author)}".ToLower(),
                    Rel = "Authors",
                    Method = "Get"
                },
                new Link
                {
                    Href = $"{httpContext.GetScheme()}://{this.httpContext.GetHost()}/{nameof(Category)}".ToLower(),
                    Rel = "Categories",
                    Method = "Get"
                },
                new Link
                {
                    Href = $"{httpContext.GetScheme()}://{this.httpContext.GetHost()}/{nameof(Review)}".ToLower(),
                    Rel = "Reviews",
                    Method = "Get"
                },
            };

            return links;
        }
    }
}