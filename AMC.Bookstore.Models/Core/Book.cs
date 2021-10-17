using System;
using System.Collections.Generic;
using AMC.Bookstore.Models.Interfaces;

namespace AMC.Bookstore.Models.Core
{
    public class Book : IBookstoreResource
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? PublishDate { get; set; }
        public string CoverImageUrl { get; set; }
        public int AuthorId { get; set; }
        public int CategoryId { get; set; }

        public IList<Link> Links { get; set; }
    }
}
