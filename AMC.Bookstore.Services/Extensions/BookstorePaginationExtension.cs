using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AMC.Bookstore.DataAccess.Models;
using AMC.Bookstore.Models;
using AMC.Bookstore.Models.Interfaces;
using AMC.Bookstore.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AMC.Bookstore.Services.Extensions
{
    public static class BookstorePaginationExtension
    {
        public async static Task<BookstoreResourceCollection<E>> PaginateAsync<T, E>(
            this IQueryable<T> query,
            System.Func<T, object> orderBySelector,
            int page,
            int limit,
            IResourceBuilder resourceBuilder) where T : IBookstoreDataModel where E : IBookstoreResource
        {

            var paged = new BookstoreResourceCollection<E>();

            page = (page < 0) ? 1 : page;

            paged.CurrentPage = page;
            paged.PageSize = limit;

            var totalItemsCountTask = query.CountAsync();

            var startRow = (page - 1) * limit;
            
            var results = (IEnumerable<T>)query;

            if (limit > 0)
            {
                results = query
                       .OrderBy(orderBySelector)
                       .Skip(startRow)
                       .Take(limit);
            }
            else
            {
                results = query;
            }

            paged.Values = results.Select(r => (E)resourceBuilder.CreateResource(r));
            paged.TotalItems = await totalItemsCountTask;
            paged.TotalPages = limit > 0 ? (int)Math.Ceiling(paged.TotalItems / (double)limit) : 0;

            paged.Links = new List<Link> { resourceBuilder.GetLinkBuilder().BuildSelfLink() };

            return paged;
        }
    }
}