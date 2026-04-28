namespace BookStore.Core.Models
{
    /// <summary>
    /// Data transfer object for order information
    /// </summary>
    public class OrderDto
    {
        /// <summary>
        /// Order identifier
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Order number
        /// </summary>
        public string? OrderNumber { get; set; }

        /// <summary>
        /// Date when the order was placed
        /// </summary>
        public DateTime OrderDate { get; set; }

        /// <summary>
        /// Total amount of the order
        /// </summary>
        public decimal TotalAmount { get; set; }

        /// <summary>
        /// List of items in the order
        /// </summary>
        public List<OrderItemDto> OrderItems { get; set; } = [];
    }
}