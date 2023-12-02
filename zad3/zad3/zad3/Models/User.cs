using Microsoft.AspNetCore.Identity;

namespace zad3.Models;

public class User : IdentityUser
{
    public string Username { get; set; }
}