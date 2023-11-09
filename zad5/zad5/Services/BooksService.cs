using zad5.Models;

namespace zad5.Services;

public class BooksService : IBooksService
{
    public async Task<List<Book>?> FetchAllBooksAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<Book?> FetchBookAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<Guid> CreateBookAsync(BookDTO book)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateBookAsync(Guid id, BookDTO book)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteBookAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}