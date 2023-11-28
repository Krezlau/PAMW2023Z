using System.Windows.Input;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using zad7.Models;
using zad7.Services;

namespace zad7.ViewModels;

[QueryProperty(nameof(Id), "id")]
public class BookDetailsViewModel : ObservableObject
{
    private readonly IBooksService _booksService;

    public BookDetailsViewModel(IBooksService booksService)
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
        set => SetProperty(ref _book, value);
    }

    public ICommand DeleteBookCommand => new AsyncRelayCommand(DeleteBookAsync);

    private async Task DeleteBookAsync()
    {
        await _booksService.DeleteBookAsync(Book.Id);
        await Shell.Current.GoToAsync("..");
    }
    
    public ICommand EditBookCommand => new AsyncRelayCommand(EditBookAsync);

    private async Task EditBookAsync()
    {
        await Shell.Current.GoToAsync($"{nameof(EditBookPage)}?id={Book.Id}");
    }
}