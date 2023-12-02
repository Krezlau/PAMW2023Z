using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using zad3.Models;
using zad3.Services;

namespace zad3.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class AuthController : Controller 
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost]
    public async Task<ActionResult<AuthResponseDTO>> Login([FromBody] LoginRequestDTO request)
    {
        try
        {
            var response = await _authService.LoginAsync(request);
            return Ok(response);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    [HttpPost("register")]
    public async Task<ActionResult<AuthResponseDTO>> Register([FromBody] RegisterRequestDTO request)
    {
        try
        {
            var response = await _authService.RegisterAsync(request);
            return Ok(response);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    [HttpPost("change-password")]
    [Authorize]
    public async Task<ActionResult<AuthResponseDTO>> ChangePassword([FromBody] ChangePasswordRequestDTO request)
    {
        try
        {
            await _authService.ChangePasswordAsync(request, Request.Headers.Authorization.ToString().Substring(7));
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
}