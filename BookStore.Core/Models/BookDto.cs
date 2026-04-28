namespace BookStore.Core.Models
{
    /// <summary>
    /// Data transfer object for book information
    /// </summary>
    public class BookDto
    {
        /// <summary>
        /// Book identifier
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
    }
}