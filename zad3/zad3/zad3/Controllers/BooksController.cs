using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using zad3.Models;
using zad3.Services;

namespace zad3.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class BooksController : Controller
{
    private readonly IBooksService _booksService;

    public BooksController(IBooksService booksService)
    {
        _booksService = booksService;
    }
    
    [HttpGet]
    public async Task<ActionResult<List<Book>>> GetBooks()
    {
        try
        {
            return Ok(await _booksService.FetchAllBooksAsync());
        } 
        catch (Exception e)
        {
            return BadRequest("Something went wrong");
        }
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<Book>> GetBookById(Guid id)
    {
        try
        {
            return Ok(await _booksService.FetchBookByIdAsync(id));
        }
        catch (KeyNotFoundException e)
        {
            return NotFound(e.Message);
        }
        catch (Exception e)
        {
            return BadRequest("Something went wrong");
        }
    }
    
    [HttpPost]
    public async Task<ActionResult<Guid>> CreateBook(BookDTO book)
    {
        try
        {
            var guid = await _booksService.CreateBookAsync(book);
            return CreatedAtAction(nameof(GetBookById), new {id = guid}, guid);
        }
        catch (ArgumentException e)
        {
            return BadRequest(e.Message);
        }
        catch (Exception e)
        {
            return BadRequest("Something went wrong");
        }
    }
    
    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateBook(Guid id, BookDTO book)
    {
        try
        {
            await _booksService.UpdateBookAsync(id, book);
            return Ok();
        }
        catch (ArgumentException e)
        {
            return BadRequest(e.Message);
        }
        catch (Exception e)
        {
            return BadRequest("Something went wrong");
        }
    }
    
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteBook(Guid id)
    {
        try
        {
            await _booksService.DeleteBookAsync(id);
            return Ok();
        }
        catch (ArgumentException e)
        {
            return BadRequest(e.Message);
        }
        catch (Exception e)
        {
            return BadRequest("Something went wrong");
        }
    }
}