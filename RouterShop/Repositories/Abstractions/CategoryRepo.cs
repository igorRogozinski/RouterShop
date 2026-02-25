using Microsoft.EntityFrameworkCore;
using RouterShop.Context;
using RouterShop.Models;
using RouterShop.Repositories.Interfaces;

namespace RouterShop.Repositories.Abstractions
{
    public class CategoryRepo : ICategoryRepo
    {
        private readonly DBContext _context;
        public CategoryRepo(DBContext context) 
        { 
            _context = context;
        }
        public async Task<List<Category>> GetAll()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category?> GetById(int id)
        {
            return await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
