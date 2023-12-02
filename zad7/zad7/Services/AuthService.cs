namespace zad7.Services;

public class AuthService : IAuthService
{
    public bool isLoggedIn { get; set; }
    public string? Token { get; set; }
    public string? Username { get; set; }
    public string? UserId { get; set; }
    public async Task<string?> LoginAsync(string email, string password)
    {
        throw new NotImplementedException();
    }

    public async Task<string?> RegisterAsync(string email, string username, string password)
    {
        throw new NotImplementedException();
    }

    public async Task<string?> ChangePasswordAsync(string oldPassword, string newPassword)
    {
        throw new NotImplementedException();
    }
}