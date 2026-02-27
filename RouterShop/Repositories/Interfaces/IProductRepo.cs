using RouterShop.Models;
using RouterShop.Models.DTO;

namespace RouterShop.Repositories.Interfaces
{
    public interface IProductRepo : IGenericRepo<Product>
    {
        public Task<List<Product>> GetPaginated(ProductFilterDto filter);
        public Task<int> GetProductCount();
    }
}
