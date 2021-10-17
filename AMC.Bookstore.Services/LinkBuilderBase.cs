using System.Collections.Generic;
using AMC.Bookstore.Models;
using AMC.Bookstore.Models.Interfaces;
using AMC.Bookstore.Services.Interfaces;

namespace AMC.Bookstore.Services
{
    public abstract class LinkBuilderBase : ILinkBuilder
    {
        protected readonly IHttpContextService httpContext;
        public LinkBuilderBase(
            IHttpContextService context)
        {
            httpContext = context;
        }

        public IList<Link> BuildLinks(IBookstoreResource resource)
        {
            var links = BuildCustomLinks(resource);
            links.Add(BuildSelfLink(resource));
            return links;
        }

        public Link BuildSelfLink(IBookstoreResource resource)
        {
            return new Link
            {
                Href = $"{httpContext.GetScheme()}://{httpContext.GetHost()}/{resource.GetType().Name}/{resource.Id}".ToLower(),
                Rel = "self",
                Method = "GET"
            };
        }

        public Link BuildSelfLink()
        {
            return new Link
            {
                Href = httpContext.GetCurrentUri().ToLower(),
                Rel = "self",
                Method = "GET"
            };
        }

        public abstract IList<Link> BuildCustomLinks(IBookstoreResource resource);

        public virtual IList<Link> BuildBookstoreHomePageLinks()
        {
            return null;
        }
    }
}