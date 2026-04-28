using AutoMapper;
using BookStore.Core.Entities;
using BookStore.Core.Interfaces;
using BookStore.Core.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace BookStore.API.Controllers
{
    /// <summary>
    /// API controller for book operations
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController(IBookRepository bookRepository, IMapper mapper) : ControllerBase
    {
        private readonly IBookRepository _bookRepository = bookRepository;
        private readonly IMapper _mapper = mapper;

        /// <summary>
        /// Get all books with optional filtering
        /// </summary>
        /// <param name="title">Filter by book title (contains)</param>
        /// <param name="publishDate">Filter by publish date (exact date)</param>
        /// <returns>List of books</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookDto>>> GetBooks(string? title = null, DateTime? publishDate = null)
        {
            Expression<Func<Book, bool>>? filter = null;

            if (!string.IsNullOrEmpty(title))
            {
                filter = b => b.Title!.Contains(title);
            }

            if (publishDate.HasValue)
            {
                filter = b => b.PublishDate.Date == publishDate.Value.Date;
            }

            var books = await _bookRepository.GetAllAsync(filter);
            var bookDtos = _mapper.Map<IEnumerable<BookDto>>(books);

            return Ok(bookDtos);
        }

        /// <summary>
        /// Get a book by its ID
        /// </summary>
        /// <param name="id">Book identifier</param>
        /// <returns>Book details</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<BookDto>> GetBook(int id)
        {
            var book = await _bookRepository.GetByIdAsync(id);

            if (book == null)
            {
                return NotFound();
            }

            var bookDto = _mapper.Map<BookDto>(book);

            return Ok(bookDto);
        }
    }
}