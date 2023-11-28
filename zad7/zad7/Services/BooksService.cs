﻿using System.Text.Json;
using zad7.Models;

namespace zad7.Services;

public class BooksService : IBooksService
{
    public async Task<List<Book>?> FetchAllBooksAsync()
    {
        using var client = new HttpClient();
        var response = await client.GetAsync("http://10.0.2.2:5044/api/books");
        response.EnsureSuccessStatusCode();
        var responseBody = await response.Content.ReadAsStringAsync();
        var books = JsonSerializer.Deserialize<List<Book>>(responseBody, new JsonSerializerOptions() {PropertyNameCaseInsensitive = true});
        return books;
    }

    public async Task<Book?> FetchBookByIdAsync(Guid id)
    {
        using var client = new HttpClient();
        var response = await client.GetAsync($"http://10.0.2.2:5044/api/books/{id.ToString()}");
        response.EnsureSuccessStatusCode();
        var responseBody = await response.Content.ReadAsStringAsync();
        var book = JsonSerializer.Deserialize<Book>(responseBody, new JsonSerializerOptions() {PropertyNameCaseInsensitive = true});
        return book;
    }

    public async Task<Guid> CreateBookAsync(BookDTO book)
    {
        using var client = new HttpClient();
        var response = await client.PostAsync("http://10.0.2.2:5044/api/books", new StringContent(JsonSerializer.Serialize(book), System.Text.Encoding.UTF8, "application/json"));
        response.EnsureSuccessStatusCode();
        var responseBody = await response.Content.ReadAsStringAsync();
        var guid = JsonSerializer.Deserialize<Guid>(responseBody, new JsonSerializerOptions() {PropertyNameCaseInsensitive = true});
        return guid;
    }

    public async Task DeleteBookAsync(Guid id)
    {
        using var client = new HttpClient();
        var response = await client.DeleteAsync($"http://10.0.2.2:5044/api/books/{id}");
        response.EnsureSuccessStatusCode();
    } 
    
    public async Task UpdateBookAsync(Guid id, BookDTO book)
    {
        using var client = new HttpClient();
        var response = await client.PutAsync($"http://10.0.2.2:5044/api/books/{id}", new StringContent(JsonSerializer.Serialize(book), System.Text.Encoding.UTF8, "application/json"));
        response.EnsureSuccessStatusCode();
    }
}