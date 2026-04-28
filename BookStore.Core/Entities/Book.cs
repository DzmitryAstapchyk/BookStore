namespace BookStore.Core.Entities
{
    /// <summary>
    /// Represents a book in the store
    /// </summary>
    public class Book
    {
        /// <summary>
        /// Unique identifier for the book
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Title of the book
        /// </summary>
        public string? Title { get; set; }

        /// <summary>
        /// Author of the book
        /// </summary>
        public string? Author { get; set; }

        /// <summary>
        /// Description of the book
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Price of the book
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Date when the book was published
        /// </summary>
        public DateTime PublishDate { get; set; }

        /// <summary>
        /// Navigation property for orders containing this book
        /// </summary>
        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}