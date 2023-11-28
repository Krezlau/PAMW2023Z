using zad7.Models;

namespace zad7.Services;

public interface IBooksService
{
    Task<List<Book>?> FetchAllBooksAsync();
    Task<Book?> FetchBookByIdAsync(Guid id);
    Task<Guid> CreateBookAsync(BookDTO book);
    Task DeleteBookAsync(Guid id); 
    Task UpdateBookAsync(Guid id, BookDTO book);
}