using RouterShop.Models;
using RouterShop.Repositories.Interfaces;
using RouterShop.Services.Interfaces;

namespace RouterShop.Services.Abstractions
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepo _categoryRepo;
        public CategoryService(ICategoryRepo categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }
        public async Task<List<Category>> GetAll()
        {
            return await _categoryRepo.GetAll();
        }

        public async Task<Category?> GetById(int id)
        {
            return await _categoryRepo.GetById(id);
        }
    }
}
