using System.Collections.Generic;

namespace AMC.Bookstore.Models.Interfaces
{
    public interface IPagedResource<T>
    {
        int PageSize { get; set; }
        int CurrentPage { get; set; }
        int TotalItems { get; set; }
        int TotalPages { get; set; }
        IEnumerable<T> Values { get; set; }
    }
}