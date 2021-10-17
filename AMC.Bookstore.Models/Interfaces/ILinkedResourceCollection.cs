using System.Collections.Generic;

namespace AMC.Bookstore.Models.Interfaces
{
    public interface ILinkedResourceCollection<T> : ILinkedResource where T : ILinkedResource
    {
        IEnumerable<T> Values { get; set; }
    }
}