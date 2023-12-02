using System.Windows.Input;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using zad7.Services;

namespace zad7.ViewModels;

public class LoginViewModel : ObservableObject
{
    private readonly IAuthService _authService;

    public LoginViewModel(IAuthService authService)
    {
        _authService = authService;
    }

    private string _email = string.Empty;
    private string _password = string.Empty;
    private string _errorMessage = string.Empty;
    
    public string Email
    {
        get => _email;
        set => SetProperty(ref _email, value);
    }

    public string Password
    {
        get => _password;
        set => SetProperty(ref _password, value);
    }
    
    public string ErrorMessage
    {
        get => _errorMessage;
        set => SetProperty(ref _errorMessage, value);
    }

    public ICommand SubmitCommand => new AsyncRelayCommand(Submit); 

    private async Task Submit()
    {
        string? error = await _authService.LoginAsync(Email, Password);
        if (error is not null)
        {
            ErrorMessage = error;
            return;
        }
        ErrorMessage = string.Empty;
        await Shell.Current.GoToAsync("HomePage");
    }

    public ICommand RegisterCommand => new AsyncRelayCommand(Register);

    private async Task Register()
    {
        await Shell.Current.GoToAsync("RegisterPage");
    }
}