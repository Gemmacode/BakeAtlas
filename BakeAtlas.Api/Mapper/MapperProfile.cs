using AutoMapper;
using BakeAtlas.Domain.Entities;

namespace BakeAtlas.Api.MapperProfile
{
    public class MapperProfile : Profile
        
    {
        public MapperProfile()
        {
            CreateMap<CustomerDTO, Customer>().ReverseMap();
            CreateMap<BakeryProductDTO, BakeryProduct>().ReverseMap();
           
            CreateMap<OrderDTO, Order>().ReverseMap();

        }
    }
}
