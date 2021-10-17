using System;
using System.Collections.Generic;
using AMC.Bookstore.Models.Interfaces;

namespace AMC.Bookstore.Models.Core
{
    public class Review : IBookstoreResource
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Content { get; set; }
        public int Rating { get; set; }
        public int BookId { get; set; } 
        public DateTime? PublishDate { get; set; }
        public IList<Link> Links { get; set; }
    }
}
