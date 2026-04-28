using BookStore.Core.Entities;
using BookStore.Core.Interfaces;
using BookStore.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BookStore.Infrastructure.Repositories
{
    /// <summary>
    /// Implementation of IOrderRepository using EF Core
    /// </summary>
    public class OrderRepository(BookStoreDbContext context) : IOrderRepository
    {
        private readonly BookStoreDbContext _context = context;

        public async Task<IEnumerable<Order>> GetAllAsync(Expression<Func<Order, bool>>? filter = null)
        {
            IQueryable<Order> query = _context.Orders.Include(o => o.OrderItems).ThenInclude(oi => oi.Book);

            if (filter != null)
            {
                query = query.Where(filter);
            }

            return await query.ToListAsync();
        }

        public async Task<Order?> GetByIdAsync(int id)
        {
            return await _context.Orders
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Book)
                .FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task AddAsync(Order order)
        {
            // Generate order number
            order.OrderNumber = $"ORD-{DateTime.Now:yyyyMMdd-HHmmss}";

            // Set order date
            order.OrderDate = DateTime.Now;

            // Calculate total amount
            order.TotalAmount = order.OrderItems.Sum(oi => oi.Quantity * oi.UnitPrice);

            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Order order)
        {
            _context.Orders.Update(order);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Order order)
        {
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
        }
    }
}