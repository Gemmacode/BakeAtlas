using AutoMapper;
using BakeAtlas.Application.DTO;
using BakeAtlas.Domain.Entities;

namespace BakeAtlas.Api.MapperProfile
{
    public class MapperProfile : Profile
        
    {
        public MapperProfile()
        {
            CreateMap<Customer, CustomerDTO>().ReverseMap();
            CreateMap<Order, OrderDTO>().ReverseMap();   
            CreateMap<BakeryProduct, BakeryProductDTO>().ReverseMap();
            CreateMap<OrderItemDTO, OrderItem>().ReverseMap();

        }
    }
}
