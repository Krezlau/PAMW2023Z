using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace zad5.Models;

public class Book
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
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