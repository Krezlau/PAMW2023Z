using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace zad3.Models;

public class Author
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    [Required]
    [MaxLength(25)]
    public string Name { get; set; } = "";
    [Required]
    [MaxLength(25)]
    public string Surname { get; set; } = "";
    [MaxLength(1024)]
    public string? Bio { get; set; }
    public virtual List<Book> Books { get; set; } = new();
}