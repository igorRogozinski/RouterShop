
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

        public async Task<ProductPaginated> GetProductsPaginated(int pageNumber, int pageSize)
        {
            var totalProducts = await _productRepo.GetProductCount();
            var totalPages = (int)Math.Ceiling((double)totalProducts / pageSize);
            if(totalPages == 0)
            {
                pageNumber = 1;
            }
            else if (pageNumber > totalPages)
            {
                pageNumber = totalPages;
            }
            var products = await _productRepo.GetPaginated(pageNumber,pageSize);
            var paginatedProducts = _mapper.Map<List<ProductListDto>>(products);

            return new ProductPaginated
            {
                Products = paginatedProducts,
                PageSize = pageSize,
                CurrentPage = pageNumber,
                TotalPages = totalPages
            };
        }
    }
}
