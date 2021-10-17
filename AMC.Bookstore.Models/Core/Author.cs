using System.Collections.Generic;
using AMC.Bookstore.Models.Interfaces;

namespace AMC.Bookstore.Models.Core
{
    public class Author : IBookstoreResource
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Headshot { get; set; }
        public IList<Link> Links { get; set; }
    }
}
