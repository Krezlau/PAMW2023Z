using System.Text.Json;
using zad6.Models;

namespace zad6.Services;

public class AuthService : IAuthService
{
    public bool isLoggedIn { get; set; }
    public string? Token { get; set; }
    public string? Username { get; set; }
    public string? UserId { get; set; }
    
    public Action? AuthStateChanged { get; set; }
    
    public async Task<string?> LoginAsync(string email, string password)
    {
        using var client = new HttpClient();
        
        var loginRequest = new LoginRequestDTO() { Email = email, Password = password };
        var body = new StringContent(JsonSerializer.Serialize(loginRequest), System.Text.Encoding.UTF8, "application/json");
        var response = await client.PostAsync("http://localhost:5044/api/auth", body);
        
        if (!response.IsSuccessStatusCode)
            return await response.Content.ReadAsStringAsync();
        
        var responseBody = await response.Content.ReadAsStringAsync();
        var authResponse = JsonSerializer.Deserialize<AuthResponseDTO>(responseBody, new JsonSerializerOptions() {PropertyNameCaseInsensitive = true});
        
        isLoggedIn = true;
        Token = authResponse.Token;
        Username = authResponse.Username;
        UserId = authResponse.UserId;
        AuthStateChanged?.Invoke();
        
        return null;
    }

    public async Task<string?> RegisterAsync(string email, string username, string password)
    {
        using var client = new HttpClient();
        
        var registerRequest = new RegisterRequestDTO() { Email = email, Password = password, Username = username};
        var body = new StringContent(JsonSerializer.Serialize(registerRequest), System.Text.Encoding.UTF8, "application/json");
        var response = await client.PostAsync("http://localhost:5044/api/auth/register", body);
        
        if (!response.IsSuccessStatusCode)
            return await response.Content.ReadAsStringAsync();
        
        var responseBody = await response.Content.ReadAsStringAsync();
        var authResponse = JsonSerializer.Deserialize<AuthResponseDTO>(responseBody, new JsonSerializerOptions() {PropertyNameCaseInsensitive = true});
        
        isLoggedIn = true;
        Token = authResponse.Token;
        Username = authResponse.Username;
        UserId = authResponse.UserId;
        
        //AuthStateChanged?.Invoke();
        
        return null;
    }

    public async Task<string?> ChangePasswordAsync(string oldPassword, string newPassword)
    {
        using var client = new HttpClient();
        
        var changePasswordRequest = new ChangePasswordRequestDTO() { NewPassword = newPassword, OldPassword = oldPassword};
        var body = new StringContent(JsonSerializer.Serialize(changePasswordRequest), System.Text.Encoding.UTF8, "application/json");
        client.DefaultRequestHeaders.Add("Authorization", $"Bearer {Token}");
        var response = await client.PostAsync("http://localhost:5044/api/auth/change-password", body);

        if (!response.IsSuccessStatusCode)
            return "Could not change password";
        
        return null;
    }
    
    public void Logout()
    {
        isLoggedIn = false;
        Token = null;
        Username = null;
        UserId = null;
        
        AuthStateChanged?.Invoke();
    }
}