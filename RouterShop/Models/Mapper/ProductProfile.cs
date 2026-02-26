using AutoMapper;
using RouterShop.Models.DTO;

namespace RouterShop.Models.Mapper
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductListDto>().ForMember(
                p=>p.ImageUrl, opt=>opt.MapFrom(src=>src.ProductImages.FirstOrDefault(pi=>pi.DefaultImage).ImageUrl)
                );
        }
    }
}
