using AutoMapper;
using BookStore.Core.Entities;
using BookStore.Core.Models;

namespace BookStore.Infrastructure.Mappings
{
    /// <summary>
    /// AutoMapper profile for mapping between entities and DTOs
    /// </summary>
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // Book mappings
            CreateMap<Book, BookDto>();
            CreateMap<BookDto, Book>();

            // Order mappings
            CreateMap<Order, OrderDto>();
            CreateMap<OrderDto, Order>();

            // OrderItem mappings
            CreateMap<OrderItem, OrderItemDto>()
                .ForMember(dest => dest.BookTitle, opt => opt.MapFrom(src => src.Book != null ? src.Book.Title : null));
            CreateMap<OrderItemDto, OrderItem>();
        }
    }
}