using zad6.Models;

namespace zad6.Services;

public interface IBookService
{
    Task<List<Book>?> FetchAllBooksAsync();
    Task<Book?> FetchBookAsync(Guid id);
    Task<Guid> CreateBookAsync(BookDTO book);
    Task DeleteBookAsync(Guid id);
}