using System.Windows.Input;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using zad7.Services;

namespace zad7.ViewModels;

public class RegisterViewModel : ObservableObject
{
    private readonly IAuthService _authService;

    public RegisterViewModel(IAuthService authService)
    {
        _authService = authService;
    }
    
    private string _email = "";
    public string Email
    {
        get => _email;
        set => SetProperty(ref _email, value);
    }
    
    private string _username = "";
    public string Username
    {
        get => _username;
        set => SetProperty(ref _username, value);
    }
    
    private string _password = "";
    public string Password
    {
        get => _password;
        set => SetProperty(ref _password, value);
    }
    
    private string _repeatPassword = "";
    public string RepeatPassword
    {
        get => _repeatPassword;
        set => SetProperty(ref _repeatPassword, value);
    }
    
    private string _errorMessage = "";
    public string ErrorMessage
    {
        get => _errorMessage;
        set => SetProperty(ref _errorMessage, value);
    }

    public ICommand SubmitCommand => new AsyncRelayCommand(Submit); 

    private async Task Submit()
    {
        if (Password != RepeatPassword)
        {
            ErrorMessage = "Passwords do not match";
            return;
        }
        string? error = await _authService.RegisterAsync(Email, Username, Password);
        if (error is not null)
        {
            ErrorMessage = error;
            return;
        }
        ErrorMessage = string.Empty;
        await Shell.Current.GoToAsync("HomePage");
    }
    
    public ICommand LoginCommand => new AsyncRelayCommand(Login);
    
    private async Task Login()
    {
        await Shell.Current.GoToAsync("LoginPage");
    }
}