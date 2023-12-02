using zad3.Models;

namespace zad3.Services;

public interface IAuthService
{
    Task<AuthResponseDTO> LoginAsync(LoginRequestDTO loginRequestDTO);
    Task<AuthResponseDTO> RegisterAsync(RegisterRequestDTO registerRequestDTO);
    Task ChangePasswordAsync(ChangePasswordRequestDTO changePasswordRequestDTO, string token);
    string ReadUserIdFromToken(string token);
}