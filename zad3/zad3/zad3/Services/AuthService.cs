using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using zad3.Database;
using zad3.Models;

namespace zad3.Services;

public class AuthService : IAuthService
{
    private readonly UserManager<User> _userManager;
    private readonly byte[] _secretKey = Encoding.ASCII.GetBytes("this is my custom Secret key for authentication");

    public AuthService(UserManager<User> userManager, SignInManager<User> signInManager, BooksDbContext context)
    {
        _userManager = userManager;
    }

    public async Task<AuthResponseDTO> LoginAsync(LoginRequestDTO loginRequestDTO)
    {
        User? user = await _userManager.FindByEmailAsync(loginRequestDTO.Email);

        if (user is null)
            throw new ArgumentException($"User with email {loginRequestDTO.Email} does not exist");

        var result = await _userManager.CheckPasswordAsync(user, loginRequestDTO.Password);

        if (!result)
            throw new ArgumentException($"Invalid password for user {loginRequestDTO.Email}");

        return new AuthResponseDTO()
        {
            Token = GenerateJwtToken(user),
            Username = user.Username,
            UserId = user.Id
        };
    }

    public async Task<AuthResponseDTO> RegisterAsync(RegisterRequestDTO registerRequestDTO)
    {
        User? user = await _userManager.FindByEmailAsync(registerRequestDTO.Email);

        if (user is not null)
            throw new ArgumentException($"User with email {registerRequestDTO.Email} already exists");

        User newUser = new User()
        {
            Email = registerRequestDTO.Email,
            UserName = registerRequestDTO.Username
        };

        var result = await _userManager.CreateAsync(newUser, registerRequestDTO.Password);

        if (!result.Succeeded)
            throw new ArgumentException($"Could not create user with email {registerRequestDTO.Email}");

        return new AuthResponseDTO()
        {
            Token = GenerateJwtToken(newUser),
            Username = newUser.Username,
            UserId = newUser.Id
        };
    }

    public async Task ChangePasswordAsync(ChangePasswordRequestDTO changePasswordRequestDTO)
    {
        User? user = await _userManager.FindByNameAsync(changePasswordRequestDTO.Username);

        if (user is null)
            throw new ArgumentException($"User with username {changePasswordRequestDTO.Username} does not exist");

        var result = await _userManager.ChangePasswordAsync(user, changePasswordRequestDTO.OldPassword,
            changePasswordRequestDTO.NewPassword);

        if (!result.Succeeded)
            throw new ArgumentException($"Could not change password for user {changePasswordRequestDTO.Username}");
    }
    
    private string GenerateJwtToken(User user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.NameIdentifier, user.Id)
            }),
            Expires = DateTime.UtcNow.AddDays(1),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(_secretKey),
                SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}