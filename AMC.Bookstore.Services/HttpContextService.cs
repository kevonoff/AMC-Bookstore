using AMC.Bookstore.Services.Interfaces;
using Microsoft.AspNetCore.Http;

namespace AMC.Bookstore.Services
{
    public class HttpContextService : IHttpContextService
    {
        private readonly HttpContext httpContext;
        public HttpContextService(
            IHttpContextAccessor httpContextAccessor)
        {
            httpContext = httpContextAccessor.HttpContext;
        }

        public string GetScheme()
        {
            return httpContext.Request.Scheme;
        }

        public string GetHost()
        {
            return httpContext.Request.Host.Value;
        }

        public string GetCurrentUri()
        {
            return $"{httpContext.Request.Scheme}://{httpContext.Request.Host.Value}{httpContext.Request.Path}";
        }

    }
}