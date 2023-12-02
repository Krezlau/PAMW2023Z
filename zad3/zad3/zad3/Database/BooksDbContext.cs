using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using zad3.Models;

namespace zad3.Database;

public class BooksDbContext : IdentityDbContext<User> 
{
    public BooksDbContext(DbContextOptions<BooksDbContext> options) : base(options)
    {
    }
    
    public DbSet<Book> Books { get; set; }
    public override DbSet<User> Users { get; set; }
    
protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>()
            .HasIndex(b => b.Title)
            .IsUnique();
        
        // seed data
        modelBuilder.Entity<Book>()
            .HasData(
                new List<Book>()
                {
                    new Book()
                    {
                        Id = Guid.NewGuid(),
                        Title = "Harry Potter",
                        Author = "J.K. Rowling",
                        Synopsis =
                            "Harry Potter is a series of seven fantasy novels written by British author J. K. Rowling.",
                        Rating = 4.5
                    },
                    new Book()
                    {
                        Id = Guid.NewGuid(),
                        Title = "The Lord of the Rings",
                        Author = "J.R.R. Tolkien",
                        Synopsis =
                            "The Lord of the Rings is an epic fantasy novel written by English author J. R. R. Tolkien.",
                        Rating = 5
                    },
                    new Book()
                    {
                        Id = Guid.NewGuid(),
                        Title = "The Hobbit",
                        Author = "J.R.R. Tolkien",
                        Synopsis =
                            "The Hobbit, or There and Back Again is a children's fantasy novel by English author J. R. R. Tolkien.",
                        Rating = 5
                    },
                    new Book()
                    {
                        Id = Guid.NewGuid(),
                        Title = "The Da Vinci Code",
                        Author = "Dan Brown",
                        Synopsis =
                            "The Da Vinci Code is a 2003 mystery thriller novel by Dan Brown. It is Brown's second novel to include the character Robert Langdon: the first was his 2000 novel Angels & Demons.",
                        Rating = 3.9
                    },
                    new Book()
                    {
                        Id = Guid.NewGuid(),
                        Title = "Angels & Demons",
                        Author = "Dan Brown",
                        Synopsis =
                            "Angels & Demons is a 2000 bestselling mystery-thriller novel written by American author Dan Brown and published by Pocket Books and then by Corgi Books.",
                        Rating = 4.7
                    },
                    new Book()
                    {
                        Id = Guid.NewGuid(),
                        Title = "The Lost Symbol",
                        Author = "Dan Brown",
                        Synopsis =
                            "The Lost Symbol is a 2009 novel written by American writer Dan Brown. It is a thriller set in Washington, D.C., after the events of The Da Vinci Code, and relies on Freemasonry for both its recurring theme and its major characters.",
                        Rating = 4.1
                    },
                    new Book()
                    {
                        Id = Guid.NewGuid(),
                        Title = "The Hunger Games",
                        Author = "Suzanne Collins",
                        Synopsis =
                            "The Hunger Games is a 2008 dystopian novel by the American writer Suzanne Collins. It is written in the voice of 16-year-old Katniss Everdeen, who lives in the future, post-apocalyptic nation of Panem in North America.",
                        Rating = 4.9 
                    },
                    new Book()
                    {
                        Id = Guid.NewGuid(),
                        Title = "Catching Fire",
                        Author = "Suzanne Collins",
                        Synopsis =
                            "Catching Fire is a 2009 science fiction young adult novel by the American novelist Suzanne Collins, the second book in The Hunger Games series.",
                        Rating = 2.5 
                    },
                    new Book()
                    {
                        Id = Guid.NewGuid(),
                        Title = "Mockingjay",
                        Author = "Suzanne Collins",
                        Synopsis =
                            "Mockingjay is a 2010 science fiction novel by American author Suzanne Collins. It is the last installment of The Hunger Games, following 2008's The Hunger Games and 2009's Catching Fire.",
                        Rating = 4.7 
                    },
                    new Book()
                    {
                        Id = Guid.NewGuid(),
                        Title = "The Martian",
                        Author = "Andy Weir",
                        Synopsis =
                            "The Martian is a 2011 science fiction novel written by Andy Weir. It was his debut novel under his own name. It was originally self-published in 2011; Crown Publishing purchased the rights and re-released it in 2014.",
                        Rating = 3.3 
                    }
                });
        base.OnModelCreating(modelBuilder);
    }
}