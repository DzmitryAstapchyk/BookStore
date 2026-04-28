using BookStore.Core.Entities;
using System.Linq.Expressions;

namespace BookStore.Core.Interfaces
{
    /// <summary>
    /// Repository interface for order operations
    /// </summary>
    public interface IOrderRepository
    {
        /// <summary>
        /// Get all orders with optional filtering
        /// </summary>
        Task<IEnumerable<Order>> GetAllAsync(Expression<Func<Order, bool>>? filter = null);

        /// <summary>
        /// Get an order by its ID
        /// </summary>
        Task<Order?> GetByIdAsync(int id);

        /// <summary>
        /// Add a new order
        /// </summary>
        Task AddAsync(Order order);

        /// <summary>
        /// Update an existing order
        /// </summary>
        Task UpdateAsync(Order order);

        /// <summary>
        /// Delete an order
        /// </summary>
        Task DeleteAsync(Order order);
    }
}