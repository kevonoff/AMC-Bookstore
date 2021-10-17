using System.Collections.Generic;
using AMC.Bookstore.Models;
using AMC.Bookstore.Models.Interfaces;

namespace AMC.Bookstore.Services.Interfaces
{
    public interface ILinkBuilder
    {
        IList<Link> BuildLinks(IBookstoreResource resource);
        Link BuildSelfLink();
        IList<Link> BuildBookstoreHomePageLinks();
    }
}