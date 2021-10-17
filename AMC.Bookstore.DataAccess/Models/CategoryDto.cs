namespace AMC.Bookstore.DataAccess.Models
{
    public class CategoryDto : IBookstoreDataModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
