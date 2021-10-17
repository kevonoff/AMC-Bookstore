namespace AMC.Bookstore.Services.Interfaces
{
    public interface IHttpContextService
    {
        string GetCurrentUri();
        string GetHost();
        string GetScheme();
    }
}