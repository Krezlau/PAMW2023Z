using Microsoft.EntityFrameworkCore;
using zad3.Models;

namespace zad3.Database;

public class BooksDbContext : DbContext
{
    public BooksDbContext(DbContextOptions<BooksDbContext> options) : base(options)
    {
    }
    
    public DbSet<Author> Authors { get; set; }
    public DbSet<Book> Books { get; set; }
    
protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Author>()
            .HasMany(a => a.Books)
            .WithOne(b => b.Author)
            .HasForeignKey(b => b.AuthorId);
        modelBuilder.Entity<Book>()
            .HasIndex(b => b.Title)
            .IsUnique();
    }
}