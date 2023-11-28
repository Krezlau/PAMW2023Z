using System.Windows.Input;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using zad7.Models;
using zad7.Services;

namespace zad7.ViewModels;

public class AddABookViewModel : ObservableObject
{
    private readonly IBooksService _booksService;

    public AddABookViewModel(IBooksService booksService)
    {
        _booksService = booksService;
    }
    
    private string _title = string.Empty;
    public string Title
    {
        get => _title;
        set => SetProperty(ref _title, value);
    }
    
    private string _author = string.Empty;
    public string Author
    {
        get => _author;
        set => SetProperty(ref _author, value);
    }
    
    private string _synopsis = string.Empty;
    public string Synopsis
    {
        get => _synopsis;
        set => SetProperty(ref _synopsis, value);
    }
    
    private string _rating = string.Empty;
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
    
    public ICommand SubmitCommand => new AsyncRelayCommand(SubmitAsync);

    private async Task SubmitAsync()
    {
        bool isDouble = double.TryParse(Rating, out double result);
        
        if (string.IsNullOrEmpty(Title) || string.IsNullOrEmpty(Author) || string.IsNullOrEmpty(Synopsis))
        {
            ErrorMessage = "All fields are required";
            return;
        }
        
        if (!isDouble)
        {
            ErrorMessage = "Rating must be a number";
            return;
        }

        var book = new BookDTO
        {
            Title = Title,
            Author = Author,
            Synopsis = Synopsis,
            Rating = result 
        };
        ErrorMessage = string.Empty;
        await _booksService.CreateBookAsync(book);
        await Shell.Current.GoToAsync("..");
    }
}