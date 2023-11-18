using zad5.Models;

namespace zad5.Services;

public interface IBooksService
{
    Task<List<Book>?> FetchAllBooksAsync();
    Task<Book?> FetchBookAsync(Guid id);
    Task<Guid> CreateBookAsync(BookDTO book);
    Task DeleteBookAsync(Guid id);
}