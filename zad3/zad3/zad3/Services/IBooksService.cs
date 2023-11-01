using zad3.Models;

namespace zad3.Services;

public interface IBooksService
{
    Task<List<Book>> FetchAllBooksAsync();
    Task<Book> FetchBookByIdAsync(Guid id);
    Task<Guid> CreateBookAsync(BookDTO book);
    Task UpdateBookAsync(Guid id, BookDTO book);
    Task DeleteBookAsync(Guid id);
}