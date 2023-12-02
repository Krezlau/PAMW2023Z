﻿namespace zad7.Services;

public interface IAuthService
{
    bool isLoggedIn { get; set; } 
    string? Token { get; set; }
    string? Username { get; set; }
    string? UserId { get; set; }
    
    Task<string?> LoginAsync(string email, string password);
    Task<string?> RegisterAsync(string email, string username, string password);
    Task<string?> ChangePasswordAsync(string oldPassword, string newPassword);
    void Logout();
}