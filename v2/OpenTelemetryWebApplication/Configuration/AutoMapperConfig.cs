using AutoMapper;
using OpenTelemetryWebApplication.Domain.Models;
using OpenTelemetryWebApplication.Dtos.Book;
using OpenTelemetryWebApplication.Dtos.Category;
using OpenTelemetryWebApplication.Dtos.Inventory;
using OpenTelemetryWebApplication.Dtos.Order;
using Microsoft.AspNetCore.Identity;
using System.Numerics;

namespace OpenTelemetryWebApplication.Configuration
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Category, CategoryAddDto>().ReverseMap();
            CreateMap<Category, CategoryEditDto>().ReverseMap();
            CreateMap<Category, CategoryResultDto>().ReverseMap();
            
            CreateMap<Book, BookAddDto>().ReverseMap();
            CreateMap<Book, BookEditDto>().ReverseMap();
            CreateMap<Book, BookResultDto>().ReverseMap();
            
            CreateMap<InventoryResultDto, Inventory>()
                .ForMember(x => x.Id, opt => opt.MapFrom(m => m.BookId))
                .ForMember(x => x.Amount, opt => opt.MapFrom(m => m.Amount))
                .ForMember(x => x.Book, opt => opt.Ignore())
                .ReverseMap();
            CreateMap<InventoryEditDto, Inventory>()
                .ForMember(x => x.Id, opt => opt.MapFrom(m => m.BookId))
                .ForMember(x => x.Amount, opt => opt.MapFrom(m => m.Amount))
                .ForMember(x => x.Book, opt => opt.Ignore())
                .ReverseMap();
            CreateMap<InventoryAddDto, Inventory>()
                .ForMember(x => x.Id, opt => opt.MapFrom(m => m.BookId))
                .ForMember(x => x.Book, opt => opt.Ignore())
                .ForMember(x => x.Amount, opt => opt.MapFrom(m => m.Amount))
                .ReverseMap();
            
            CreateMap<int, Book>()
                .ForMember(x => x.Id, opt => opt.MapFrom(src => src));
            CreateMap<OrderAddDto, Order>()
                .ForMember(x => x.Books, opt => opt.MapFrom(m => m.Books));

            CreateMap<Order, OrderResultDto>()
                .ForMember(x => x.Books, opt => opt.MapFrom(m => m.Books.Select(x => x.Id).ToList()));
        }
    }
}
