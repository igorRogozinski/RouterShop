using RouterShop.Models;

namespace RouterShop.Repositories.Interfaces
{
    public interface IProductRepo : IGenericRepo<Product>
    {
        public Task<List<Product>> GetPaginated(int pageNumber, int pageSize);
        public Task<int> GetProductCount();
    }
}
