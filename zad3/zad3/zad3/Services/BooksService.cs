using Microsoft.EntityFrameworkCore;
using zad3.Database;
using zad3.Models;

namespace zad3.Services;

public class BooksService : IBooksService
{
    private readonly BooksDbContext _context;

    public BooksService(BooksDbContext context)
    {
        _context = context;
    }

    public async Task<List<Book>> FetchAllBooksAsync()
    {
        return await _context.Books.ToListAsync();
    }

    public async Task<Book> FetchBookByIdAsync(Guid id)
    {
        Book? book = await _context.Books.Where(b => b.Id == id).FirstOrDefaultAsync();
        
        if (book is null) throw new KeyNotFoundException($"Book with id {id} not found");
        
        return book;
    }

    public async Task<Guid> CreateBookAsync(BookDTO book)
    {
        Book? bookWithTheSameTitle = await _context.Books.Where(b => b.Title == book.Title).FirstOrDefaultAsync();

        if (bookWithTheSameTitle is not null)
            throw new ArgumentException($"Book with title {book.Title} already exists");
        
        Book b = new Book()
        {
            Author = book.Author,
            Synopsis = book.Synopsis,
            Title = book.Title,
            Rating = book.Rating
        };
        _context.Books.Add(b);
        await _context.SaveChangesAsync();
        return b.Id;
    }

    public async Task DeleteBookAsync(Guid id)
    {
        Book? bookWithTheId  = await _context.Books.Where(b => b.Id == id).FirstOrDefaultAsync();

        if (bookWithTheId is null)
            throw new ArgumentException($"Book with the specified id {id} does not exist");
        
        _context.Books.Remove(bookWithTheId);
        await _context.SaveChangesAsync();
    }
}