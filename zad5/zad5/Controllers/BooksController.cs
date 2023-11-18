using Microsoft.AspNetCore.Mvc;
using zad5.Models;
using zad5.Models.ViewModels;
using zad5.Services;

namespace zad5.Controllers;

public class BooksController : Controller
{
    private readonly IBooksService _booksService;

    public BooksController(IBooksService booksService)
    {
        _booksService = booksService;
    }

    // GET
    public async Task<IActionResult> Index()
    {
        try
        {
            var books = await _booksService.FetchAllBooksAsync();
            return View(new BookList() { Books = books });
        }
        catch (Exception e)
        {
            return View("Error", new ErrorViewModel() { RequestId = e.Message });
        }
    }
    
    public async Task<IActionResult> Details(Guid id)
    {
        try
        {
            var book = await _booksService.FetchBookAsync(id);
            return View(book);
        }
        catch (Exception e)
        {
            return View("Error", new ErrorViewModel() { RequestId = e.Message });
        }
    }

    public async Task<IActionResult> CreateBook()
    {
        return View();
    }
    
    [HttpPost]
    public IActionResult CreateBook(string titleValue, string authorValue, string synopsisValue, int ratingValue)
    {
        BookDTO book = new BookDTO()
        {
            Title = titleValue,
            Author = authorValue,
            Synopsis = synopsisValue,
            Rating =  ratingValue
        };
        try
        {
            // run synchronously
            _booksService.CreateBookAsync(book).Wait();
        }
        catch (Exception e)
        {
            return View("Error", new ErrorViewModel() { RequestId = e.Message });
        }
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> DeleteBook(Guid id)
    {
        try
        {
            await _booksService.DeleteBookAsync(id);
        }
        catch (Exception e)
        {
            return View("Error", new ErrorViewModel() { RequestId = e.Message });
        }
        return RedirectToAction("Index");
    }
}