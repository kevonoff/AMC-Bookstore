using System;

namespace AMC.Bookstore.DataAccess.Models
{
    public class ReviewDto : IBookstoreDataModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Content { get; set; }
        public int Rating { get; set; }
        public int BookId { get; set; } 
        public DateTime? PublishDate { get; set; }
    }
}
