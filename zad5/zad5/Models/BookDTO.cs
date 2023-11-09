using System.ComponentModel.DataAnnotations;

namespace zad5.Models;

public class BookDTO
{
    [Required]
    [MaxLength(50)]
    public string Title { get; set; }
    [Required]
    [MaxLength(50)]
    public string Author { get; set; }
    [Required]
    [MaxLength(1024)]
    public string Synopsis { get; set; } 
    [Required]
    [Range(0,5)]
    public double Rating { get; set; }
}