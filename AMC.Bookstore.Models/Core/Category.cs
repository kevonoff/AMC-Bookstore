using System.Collections.Generic;
using AMC.Bookstore.Models.Interfaces;

namespace AMC.Bookstore.Models.Core
{
    public class Category : IBookstoreResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<Link> Links { get; set; }
    }
}
