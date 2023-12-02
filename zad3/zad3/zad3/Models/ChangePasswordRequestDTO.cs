using System.ComponentModel.DataAnnotations;

namespace zad3.Models;

public class ChangePasswordRequestDTO
{
    [Required]
    public string OldPassword { get; set; }
    [Required]
    public string NewPassword { get; set; }
    [Required]
    public string Username { get; set; }
}