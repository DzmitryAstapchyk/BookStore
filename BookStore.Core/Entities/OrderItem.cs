namespace BookStore.Core.Entities
{
    /// <summary>
    /// Represents a single item in an order
    /// </summary>
    public class OrderItem
    {
        /// <summary>
        /// Unique identifier for the order item
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Quantity of books ordered
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Price at the time of ordering
        /// </summary>
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// Foreign key for the book
        /// </summary>
        public int BookId { get; set; }

        /// <summary>
        /// Navigation property to the book
        /// </summary>
        public Book? Book { get; set; }

        /// <summary>
        /// Foreign key for the order
        /// </summary>
        public int OrderId { get; set; }

        /// <summary>
        /// Navigation property to the order
        /// </summary>
        public Order? Order { get; set; }
    }
}