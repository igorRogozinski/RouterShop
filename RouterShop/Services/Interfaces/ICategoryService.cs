using RouterShop.Models;

namespace RouterShop.Services.Interfaces
{
    public interface ICategoryService
    {
        public Task<List<Category>> GetAll();
        public Task<Category?> GetById(int id);
    }
}
