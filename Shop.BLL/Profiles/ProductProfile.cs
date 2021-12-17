using AutoMapper;
using Shop.DAL.Models;
using Shop.DTO;

namespace Shop.BLL.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, CreateProductDto>();
            CreateMap<CreateProductDto, Product>();
        }
    }
}
