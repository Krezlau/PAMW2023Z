using System.Net.Http.Headers;
using System.Text.Json;
using zad6.Models;

namespace zad6.Services;

public class BookService : IBookService
{
    private readonly IAuthService _authService;

    public BookService(IAuthService authService)
    {
        _authService = authService;
    }
    
    private void CheckIfLoggedIn()
    {
        if (!_authService.isLoggedIn)
            throw new Exception("You are not logged in!");
    }

    public async Task<List<Book>?> FetchAllBooksAsync()
    {
        CheckIfLoggedIn();
        using var client = new HttpClient();
        // auth header 
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _authService.Token);
        var response = await client.GetAsync("http://localhost:5044/api/books");
        response.EnsureSuccessStatusCode();
        var responseBody = await response.Content.ReadAsStringAsync();
        var books = JsonSerializer.Deserialize<List<Book>>(responseBody, new JsonSerializerOptions() {PropertyNameCaseInsensitive = true});
        return books;
    }

    public async Task<Book?> FetchBookAsync(Guid id)
    {
        CheckIfLoggedIn();
        using var client = new HttpClient();
        // auth header 
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _authService.Token);
        var response = await client.GetAsync($"http://localhost:5044/api/books/{id.ToString()}");
        response.EnsureSuccessStatusCode();
        var responseBody = await response.Content.ReadAsStringAsync();
        var book = JsonSerializer.Deserialize<Book>(responseBody, new JsonSerializerOptions() {PropertyNameCaseInsensitive = true});
        return book;
    }

    public async Task<Guid> CreateBookAsync(BookDTO book)
    {
        CheckIfLoggedIn();
        using var client = new HttpClient();
        // auth header 
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _authService.Token);
        var response = await client.PostAsync("http://localhost:5044/api/books", new StringContent(JsonSerializer.Serialize(book), System.Text.Encoding.UTF8, "application/json"));
        response.EnsureSuccessStatusCode();
        var responseBody = await response.Content.ReadAsStringAsync();
        var guid = JsonSerializer.Deserialize<Guid>(responseBody, new JsonSerializerOptions() {PropertyNameCaseInsensitive = true});
        return guid;
    }

    public async Task DeleteBookAsync(Guid id)
    {
        CheckIfLoggedIn();
        using var client = new HttpClient();
        // auth header 
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _authService.Token);
        var response = await client.DeleteAsync($"http://localhost:5044/api/books/{id}");
        response.EnsureSuccessStatusCode();
    } 
    
    public async Task UpdateBookAsync(Guid id, BookDTO book)
    {
        CheckIfLoggedIn();
        using var client = new HttpClient();
        // auth header 
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _authService.Token);
        var response = await client.PutAsync($"http://localhost:5044/api/books/{id}", new StringContent(JsonSerializer.Serialize(book), System.Text.Encoding.UTF8, "application/json"));
        response.EnsureSuccessStatusCode();
    }
}