
using System.Windows.Input;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;

namespace zad7.ViewModels;

public partial class MainViewModel : ObservableObject
{
    public ICommand AddBookCommand { get; set; }
    public ICommand ShowBooksCommand { get; set; }

    public MainViewModel()
    {
        AddBookCommand = new RelayCommand(AddABook);
        ShowBooksCommand = new RelayCommand(ShowBooks);
    }
    
    private async void AddABook()
    {
        await Shell.Current.GoToAsync("AddABookPage");
    }

    private async void ShowBooks()
    {
        await Shell.Current.GoToAsync("BookListPage");
    }
}