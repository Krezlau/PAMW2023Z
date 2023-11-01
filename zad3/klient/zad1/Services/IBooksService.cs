using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using zad3.Models;

namespace zad1.Services;

public interface IBooksService
{
    Task<List<Book>?> FetchAllBooksAsync();
    Task<Book?> FetchBookByIdAsync(Guid id);
    Task<Guid> CreateBookAsync(BookDTO book);
    Task DeleteBookAsync(Guid id);
}