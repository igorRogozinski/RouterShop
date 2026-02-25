using RouterShop.Models;
using RouterShop.Models.DTO;

namespace RouterShop.Services.Interfaces
{
    public interface IProductService
    {
        public Task<List<ProductListDto>> GetAll();
        public Task<Product> GetById(int id);
        public Task<ProductPaginated> GetProductsPaginated(int pageNumber, int pageSize);
    }
}
