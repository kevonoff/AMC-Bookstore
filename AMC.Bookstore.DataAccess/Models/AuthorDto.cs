namespace AMC.Bookstore.DataAccess.Models
{
    public class AuthorDto : IBookstoreDataModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string HeadshotUrl { get; set; }
    }
}
