namespace BookStore.Core.Models
{
    /// <summary>
    /// Data transfer object for order item information
    /// </summary>
    public class OrderItemDto
    {
        /// <summary>
        /// Book identifier
        /// </summary>
        public int BookId { get; set; }

        /// <summary>
        /// Quantity of books ordered
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Price at the time of ordering
        /// </summary>
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// Title of the book
        /// </summary>
        public string? BookTitle { get; set; }
    }
}