using BookStore.Core.Entities;
using System.Linq.Expressions;

namespace BookStore.Core.Interfaces
{
    /// <summary>
    /// Repository interface for book operations
    /// </summary>
    public interface IBookRepository
    {
        /// <summary>
        /// Get all books with optional filtering
        /// </summary>
        Task<IEnumerable<Book>> GetAllAsync(Expression<Func<Book, bool>>? filter = null);

        /// <summary>
        /// Get a book by its ID
        /// </summary>
        Task<Book?> GetByIdAsync(int id);

        /// <summary>
        /// Add a new book
        /// </summary>
        Task AddAsync(Book book);

        /// <summary>
        /// Update an existing book
        /// </summary>
        Task UpdateAsync(Book book);

        /// <summary>
        /// Delete a book
        /// </summary>
        Task DeleteAsync(Book book);
    }
}