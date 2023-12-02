using System.Windows.Input;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using zad7.Services;

namespace zad7.ViewModels;

public class ChangePasswordViewModel : ObservableObject
{
    private readonly IAuthService _authService;

    public ChangePasswordViewModel(IAuthService authService)
    {
        _authService = authService;
    }
    
    private string _oldPassword = string.Empty;
    public string OldPassword
    {
        get => _oldPassword;
        set => SetProperty(ref _oldPassword, value);
    }
    
    private string _newPassword = string.Empty;
    public string NewPassword
    {
        get => _newPassword;
        set => SetProperty(ref _newPassword, value);
    }
    
    private string _repeatNewPassword = string.Empty;
    public string RepeatNewPassword
    {
        get => _repeatNewPassword;
        set => SetProperty(ref _repeatNewPassword, value);
    }
    
    private string _errorMessage = string.Empty;
    public string ErrorMessage
    {
        get => _errorMessage;
        set => SetProperty(ref _errorMessage, value);
    }

    public ICommand SubmitCommand => new AsyncRelayCommand(Submit);

    private async Task Submit()
    {
        ErrorMessage = string.Empty;
        if (NewPassword != RepeatNewPassword)
        {
            ErrorMessage = "Passwords do not match";
            return;
        }
        var error = await _authService.ChangePasswordAsync(OldPassword, NewPassword);

        if (error is not null)
        {
            ErrorMessage = error;
            return;
        }
        
        await Shell.Current.GoToAsync("..");
    }
    
}