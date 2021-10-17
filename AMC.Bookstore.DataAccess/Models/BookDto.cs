using System;

namespace AMC.Bookstore.DataAccess.Models
{
    public class BookDto : IBookstoreDataModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? PublishDate { get; set; }
        public string CoverImageUrl { get; set; }
        public int AuthorId { get; set; }
        public int CategoryId { get; set; }
    }
}
