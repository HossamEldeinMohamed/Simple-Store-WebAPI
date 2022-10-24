
using AutoMapper;
using Common_Utility.DTO;
using DataAccess.Entities;

namespace BusinessLayer.Mapper
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {

            CreateMap<ProductDTO, Product>().ReverseMap(); ;
            CreateMap<Product, ProductDTO>().ReverseMap(); ;
            CreateMap<UpdateProductDTO, Product>().ReverseMap(); ;
            CreateMap<Product, UpdateProductDTO>().ReverseMap(); ;
            CreateMap<OrderDTO, Order>().ReverseMap(); ;
            CreateMap<Order, OrderDTO>().ReverseMap(); ;
            CreateMap<OrderDetailDTO, OrderDetail>().ReverseMap(); ;
            CreateMap<OrderDetail, OrderDetailDTO>().ReverseMap(); ;

        }
    }
}
