
using System.Windows.Input;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using zad7.Services;

namespace zad7.ViewModels;

public partial class MainViewModel : ObservableObject
{
    public ICommand AddBookCommand { get; set; }
    public ICommand ShowBooksCommand { get; set; }
    
    private readonly IAuthService _authService;

    public MainViewModel(IAuthService authService)
    {
        _authService = authService;
        AddBookCommand = new RelayCommand(AddABook);
        ShowBooksCommand = new RelayCommand(ShowBooks);
    }
    
    public string LoggedUser => _authService.Username ?? "Not logged in";
    
    private async void AddABook()
    {
        await Shell.Current.GoToAsync("AddABookPage");
    }

    private async void ShowBooks()
    {
        await Shell.Current.GoToAsync("BookListPage");
    }
    
    public ICommand ChangePasswordCommand => new AsyncRelayCommand(ChangePasswordAsync);

    private async Task ChangePasswordAsync()
    {
        await Shell.Current.GoToAsync("ChangePasswordPage");
    }
    
    public ICommand LogoutCommand => new AsyncRelayCommand(Logout);

    private async Task Logout()
    {
        _authService.Logout();
        await Shell.Current.GoToAsync("//LoginPage");
    }
}