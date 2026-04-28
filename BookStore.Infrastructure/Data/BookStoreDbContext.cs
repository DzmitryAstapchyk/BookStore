using BookStore.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Infrastructure.Data
{
    /// <summary>
    /// Database context for the BookStore application
    /// </summary>
    public class BookStoreDbContext(DbContextOptions<BookStoreDbContext> options) : DbContext(options)
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure relationships
            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Book)
                .WithMany(b => b.OrderItems)
                .HasForeignKey(oi => oi.BookId);

            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Order)
                .WithMany(o => o.OrderItems)
                .HasForeignKey(oi => oi.OrderId);

            // Seed initial data
            modelBuilder.Entity<Book>().HasData(
                new Book { Id = 1, Title = "The Great Gatsby", Author = "F. Scott Fitzgerald", Description = "A story of wealth and love in the 1920s", Price = 10.99m, PublishDate = new DateTime(1925, 4, 10) },
                new Book { Id = 2, Title = "To Kill a Mockingbird", Author = "Harper Lee", Description = "A story of racial injustice in the American South", Price = 12.50m, PublishDate = new DateTime(1960, 7, 11) },
                new Book { Id = 3, Title = "1984", Author = "George Orwell", Description = "A dystopian novel about totalitarianism", Price = 9.99m, PublishDate = new DateTime(1949, 6, 8) }
            );
        }
    }
}