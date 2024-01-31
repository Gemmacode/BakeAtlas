using AutoMapper;
using BakeAtlas.Application.DTO;
using BakeAtlas.Domain.Entities;

namespace BakeAtlas.Api.MapperProfile
{
    public class MapperProfile : Profile
        
    {
        public MapperProfile()
        {
            CreateMap<CustomerDTO, Customer>().ReverseMap();
            CreateMap<BakeryProductDTO, BakeryProduct>().ReverseMap();
            CreateMap<OrderItemDTO, OrderItem>().ReverseMap();
            CreateMap<OrderItemDTO, OrderItem>().ReverseMap();

            CreateMap<OrderDTO, Order>()
                .ForMember(dest => dest.OrderItems, opt => opt.MapFrom(src => src.OrderItems))
                .ReverseMap();
        }
    }
}
