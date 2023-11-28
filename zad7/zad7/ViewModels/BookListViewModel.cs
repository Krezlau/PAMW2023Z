using System.Collections.ObjectModel;
using System.Windows.Input;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using zad7.Models;
using zad7.Services;

namespace zad7.ViewModels;

public partial class BookListViewModel : ObservableObject
{
    private readonly IBooksService _booksService;

    public BookListViewModel(IBooksService booksService)
    {
        _booksService = booksService;
    }
    
    private ObservableCollection<Book> _books = new();
    public ObservableCollection<Book> Books
    {
        get => _books;
        set => SetProperty(ref _books, value);
    }
    
    public ICommand LoadBooksCommand => new AsyncRelayCommand(LoadBooksAsync);
    public ICommand ViewBookDetailsCommand => new AsyncRelayCommand(ViewBookDetailsAsync);
    
    private Book _selectedBook = new();
    public Book SelectedBook
    {
        get => _selectedBook;
        set => SetProperty(ref _selectedBook, value);
    }

    private async Task LoadBooksAsync()
    {
        var books = await _booksService.FetchAllBooksAsync();
        if (books != null)
        {
            Books = new ObservableCollection<Book>(books);
        }
    }
    
    private async Task ViewBookDetailsAsync()
    {
        if (SelectedBook.Id != Guid.Empty)
            await Shell.Current.GoToAsync($"BookDetailsPage?id={SelectedBook.Id}");
    }
}