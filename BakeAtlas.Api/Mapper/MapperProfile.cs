using AutoMapper;
using BakeAtlas.Domain.Entities;

namespace BakeAtlas.Api.MapperProfile
{
    public class MapperProfile : Profile
        
    {
        public MapperProfile()
        {
            CreateMap<Customer, CustomerDTO>();
            CreateMap<Order, OrderDTO>();   
            CreateMap<BakeryProduct, BakeryProductDTO>().ReverseMap();   

        }
    }
}
