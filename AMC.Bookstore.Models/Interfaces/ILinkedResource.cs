using System.Collections.Generic;

namespace AMC.Bookstore.Models.Interfaces
{
    public interface ILinkedResource
    {
        IList<Link> Links { get; set; }
    }
}