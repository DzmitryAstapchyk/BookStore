using AutoMapper;
using BookStore.Core.Entities;
using BookStore.Core.Interfaces;
using BookStore.Core.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace BookStore.API.Controllers
{
    /// <summary>
    /// API controller for order operations
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController(
        IOrderRepository orderRepository,
        IBookRepository bookRepository,
        IMapper mapper) : ControllerBase
    {
        private readonly IOrderRepository _orderRepository = orderRepository;
        private readonly IBookRepository _bookRepository = bookRepository;
        private readonly IMapper _mapper = mapper;

        /// <summary>
        /// Get all orders with optional filtering
        /// </summary>
        /// <param name="orderNumber">Filter by order number (exact match)</param>
        /// <param name="orderDate">Filter by order date (exact date)</param>
        /// <returns>List of orders</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderDto>>> GetOrders(string? orderNumber = null, DateTime? orderDate = null)
        {
            Expression<Func<Order, bool>>? filter = null;

            if (!string.IsNullOrEmpty(orderNumber))
            {
                filter = o => o.OrderNumber! == orderNumber;
            }

            if (orderDate.HasValue)
            {
                filter = o => o.OrderDate.Date == orderDate.Value.Date;
            }

            var orders = await _orderRepository.GetAllAsync(filter);
            var orderDtos = _mapper.Map<IEnumerable<OrderDto>>(orders);

            return Ok(orderDtos);
        }

        /// <summary>
        /// Create a new order
        /// </summary>
        /// <param name="orderDto">Order data</param>
        /// <returns>Created order</returns>
        [HttpPost]
        public async Task<ActionResult<OrderDto>> CreateOrder(OrderDto orderDto)
        {
            // Validate order items
            if (orderDto.OrderItems == null || orderDto.OrderItems.Count == 0)
            {
                return BadRequest("Order must contain at least one item");
            }

            // Create order entity
            var order = _mapper.Map<Order>(orderDto);

            // Set current prices for order items
            foreach (var item in order.OrderItems)
            {
                var book = await _bookRepository.GetByIdAsync(item.BookId);
                if (book == null)
                {
                    return BadRequest($"Book with ID {item.BookId} not found");
                }
                item.UnitPrice = book.Price;
            }

            // Save order
            await _orderRepository.AddAsync(order);

            // Return created order
            var createdOrderDto = _mapper.Map<OrderDto>(order);
            return CreatedAtAction(nameof(GetOrder), new { id = order.Id }, createdOrderDto);
        }

        /// <summary>
        /// Get an order by its ID
        /// </summary>
        /// <param name="id">Order identifier</param>
        /// <returns>Order details</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDto>> GetOrder(int id)
        {
            var order = await _orderRepository.GetByIdAsync(id);

            if (order == null)
            {
                return NotFound();
            }

            var orderDto = _mapper.Map<OrderDto>(order);

            return Ok(orderDto);
        }
    }
}