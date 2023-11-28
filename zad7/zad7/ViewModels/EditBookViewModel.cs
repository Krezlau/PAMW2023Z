using System.Windows.Input;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using zad7.Models;
using zad7.Services;

namespace zad7.ViewModels;

[QueryProperty(nameof(Id), "id")]
public class EditBookViewModel : ObservableObject
{
    private readonly IBooksService _booksService;

    public EditBookViewModel(IBooksService booksService)
    {
        _booksService = booksService;
    }
    
    private string _id;
    public string Id
    {
        get => _id;
        set
        {
            SetProperty(ref _id, value);
            // fetch book details
            Task.Run(async () => Book = await _booksService.FetchBookByIdAsync(new Guid(Id)));
        }
    }
    
    private Book _book;
    public Book Book
    {
        get => _book;
        set
        {
            SetProperty(ref _book, value);
            Rating = Book.Rating.ToString();
        }
    }

    private string _rating;
    public string Rating
    {
        get => _rating;
        set => SetProperty(ref _rating, value);
    }
    
    private string _errorMessage = string.Empty;
    public string ErrorMessage
    {
        get => _errorMessage;
        set => SetProperty(ref _errorMessage, value);
    }
    

    public ICommand SubmitCommand => new AsyncRelayCommand(SaveBookAsync);
    
    private async Task SaveBookAsync()
    {
        bool isDouble = double.TryParse(Rating, out double result);
        
        if (string.IsNullOrEmpty(Book.Title) || string.IsNullOrEmpty(Book.Author) || string.IsNullOrEmpty(Book.Synopsis))
        {
            ErrorMessage = "All fields are required";
            return;
        }
        
        if (!isDouble)
        {
            ErrorMessage = "Rating must be a number";
            return;
        }
        
        var bookDTO = new BookDTO
        {
            Title = Book.Title,
            Author = Book.Author,
            Synopsis = Book.Synopsis,
            Rating = result 
        };
        await _booksService.UpdateBookAsync(new Guid(Id), bookDTO);
        await Shell.Current.GoToAsync("..");
    }
    
}