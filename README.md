This is a simple Bookstore REST service.

The root contains links to all of the base collections.

If you want books, navigate to:         {hostname}/books
If you want authors, navigate to:       {hostname}/authors
If you want categories, navigate to:    {hostname}/categories
If you want reviews, navigate to:       {hostname}/reviews

You can also retrieve nested resources. For example.
If you want to get all of the books for a particular author you would navigate to:

{hostname}/authors/{authorid}/books

There is a special endpoint that also allows you to retrieve books for a given author and category:
{hostname}/categories/{categoryId}/authors/{authorid}

There is a small sample of data that gets initialized.
All resources use integer IDs starting with 1.

Each endpoint that returns a collection of resources has 2 query parameters for paging.
numResults and resultsPerPage