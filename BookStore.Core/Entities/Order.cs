namespace BookStore.Core.Entities
{
    /// <summary>
    /// Represents a customer order
    /// </summary>
    public class Order
    {
        /// <summary>
        /// Unique identifier for the order
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Order number (for display purposes)
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
        /// Collection of items in this order
        /// </summary>
        public ICollection<OrderItem> OrderItems { get; set; } = [];
    }
}