using AutoMapper;
using RouterShop.Models.DTO;

namespace RouterShop.Models.Mapper
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductListDto>();
        }
    }
}
