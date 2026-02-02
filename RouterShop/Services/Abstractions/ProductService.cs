using RouterShop.Models;
using RouterShop.Models.DTO;
using RouterShop.Repositories.Abstractions;
using RouterShop.Services.Interfaces;

namespace RouterShop.Services.Abstractions
{
    public class ProductService : IProductService
    {
        ProductRepo _productRepo;
        public ProductService(ProductRepo productRepo)
        {
            _productRepo = productRepo;
        }
        public Task<List<ProductDto>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ProductPaginated> GetProductsPaginated(int pageNumber, int pageSize)
        {
            var products = await _productRepo.GetPaginated(pageNumber,pageSize);
            var paginatedProducts = products
                .Select(p => new ProductDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price
                })
                .ToList();
            return new ProductPaginated
            {
                Products = paginatedProducts,
                PageSize = pageSize,
                CurrentPage = pageNumber,
                TotalPages = (int)Math.Ceiling((double)products.Count / pageSize)
            };
        }
    }
}
