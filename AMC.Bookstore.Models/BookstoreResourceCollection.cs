using System.Collections.Generic;
using AMC.Bookstore.Models.Interfaces;

namespace AMC.Bookstore.Models
{
    public class BookstoreResourceCollection<T> : PagedResource<T>, ILinkedResourceCollection<T> where T : ILinkedResource
    {
        public override IEnumerable<T> Values { get; set; }
        public IList<Link> Links { get; set; }
        
    }
}