
using AutoMapper;
using RouterShop.Models;
using RouterShop.Models.DTO;
using RouterShop.Repositories.Abstractions;
using RouterShop.Repositories.Interfaces;
using RouterShop.Services.Interfaces;

namespace RouterShop.Services.Abstractions
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IProductRepo _productRepo;
        public ProductService(IProductRepo productRepo, IMapper mapper)
        {
            _productRepo = productRepo;
            _mapper = mapper;
        }
        public async Task<List<ProductListDto>> GetAll()
        {
            var products = await _productRepo.GetAll();
            return products.Select(p => _mapper.Map<ProductListDto>(p)).ToList();
        }

        public async Task<Product?> GetById(int id)
        {
            return await _productRepo.GetById(id);
        }

        public async Task<ProductPaginated> GetProductsPaginated(ProductFilterDto filter)
        {
            var totalProducts = await _productRepo.GetProductCount();
            var totalPages = (int)Math.Ceiling((double)totalProducts / filter.PageSize);
            if(totalPages == 0)
            {
                filter.PageNumber = 1;
            }
            else if (filter.PageNumber > totalPages)
            {
                filter.PageNumber = totalPages;
            }
            var products = await _productRepo.GetPaginated(filter);
            var paginatedProducts = _mapper.Map<List<ProductListDto>>(products);

            return new ProductPaginated
            {
                Products = paginatedProducts,
                PageSize = filter.PageSize,
                CurrentPage = filter.PageNumber,
                TotalPages = totalPages,
                CategoryId = filter.CategoryId
            };
        }
    }
}
