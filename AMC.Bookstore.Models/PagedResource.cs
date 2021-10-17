using System.Collections.Generic;
using AMC.Bookstore.Models.Interfaces;

namespace AMC.Bookstore.Models
{
    public abstract class PagedResource<T> : IPagedResource<T>
    {
        const int MaxPageSize = 500;
        private int _pageSize;
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
        }

        public int CurrentPage { get; set; }
        public int TotalItems { get; set; }
        public int TotalPages { get; set; }
        public abstract IEnumerable<T> Values { get; set; }

        public PagedResource()
        {
            Values = new List<T>();
        }
    }
}