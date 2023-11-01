using System;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using zad1.Services;
using zad3.Models;

namespace zad1.ViewModels;

public partial class MainWindowViewModel : ObservableObject
{
    private readonly IBooksService _booksService;

    public MainWindowViewModel(IBooksService booksService)
    {
        _booksService = booksService;
    }

    private ObservableCollection<Book> _books = new();
    public ObservableCollection<Book> Books
    {
        get => _books;
        set => SetProperty(ref _books, value);
    }
    
    private Book _selectedBook = new();

    public Book? SelectedBook
    {
        get => _selectedBook;
        set
        {
            SetProperty(ref _selectedBook, value);
            if (value is null)
            {
                SelectedBookInfo = string.Empty;
            }
            else
            {
                SelectedBookInfo = string.Join('\n', new string[] 
                {SelectedBook.Title, SelectedBook.Author, SelectedBook.Synopsis, SelectedBook.Rating.ToString(), SelectedBook.Id.ToString()});
            }
        }
    }

    
    private string _newTitle = string.Empty;
    public string NewTitle
    {
        get => _newTitle;
        set => SetProperty(ref _newTitle, value);
    }
    
    private string _newAuthor = string.Empty;
    public string NewAuthor
    {
        get => _newAuthor;
        set => SetProperty(ref _newAuthor, value);
    }
    
    private string _newSynopsis = string.Empty;
    public string NewSynopsis
    {
        get => _newSynopsis;
        set => SetProperty(ref _newSynopsis, value);
    }
    
    private string _newRating = string.Empty;
    public string NewRating
    {
        get => _newRating;
        set => SetProperty(ref _newRating, value);
    }
    
   private string _error = string.Empty;

   public string Error
   {
       get => _error;
       set => SetProperty(ref _error, value);
   }
   
    private string _selectedBookInfo;
    public string SelectedBookInfo
    {
        get => _selectedBookInfo;
        set => SetProperty(ref _selectedBookInfo, value);
    }

   [RelayCommand]
   public async void FetchAll()
   {
        Error = string.Empty;
       try
       {
           Books = new ObservableCollection<Book>(await _booksService.FetchAllBooksAsync());
       }
       catch (Exception e)
       {
           Error = e.Message;
       }
   }
    
   [RelayCommand]
   public async void DeleteSelected()
   {
        Error = string.Empty;
       try
       {
              await _booksService.DeleteBookAsync(SelectedBook.Id);
              Books.Remove(SelectedBook);
       }
       catch (Exception e)
       {
           Error = e.Message;
       }
       
   }

   [RelayCommand]
   public async void FetchSelected()
   {
        Error = string.Empty;
         try
         {
             var book = await _booksService.FetchBookByIdAsync(SelectedBook.Id);
             if (book is not null)
             {
                 SelectedBook = book;
             }
             else throw new Exception("Book not found");
         }
         catch (Exception e)
         {
              Error = e.Message;
         }
       
   }

   [RelayCommand]
   public async void AddNew()
   {
        Error = string.Empty;
       try
       {
              var book = new BookDTO()
              {
                Author = NewAuthor,
                Synopsis = NewSynopsis,
                Title = NewTitle,
                Rating = double.Parse(NewRating)
              };
              var guid = await _booksService.CreateBookAsync(book);
              Books.Add(new Book()
              {
                  Author = NewAuthor,
                  Synopsis = NewSynopsis,
                  Title = NewTitle,
                  Rating = double.Parse(NewRating),
                  Id = guid
              });

       }
       catch (Exception e)
       {
              Error = e.Message;
       }
   }
}