using Microsoft.EntityFrameworkCore;
using RouterShop.Context;
using RouterShop.Models;
using RouterShop.Repositories.Interfaces;

namespace RouterShop.Repositories.Abstractions
{
    public class ProductRepo : IProductRepo
    {
        private readonly DBContext _context;
        public ProductRepo(DBContext context) 
        {
            _context = context;
        }
        public async Task<List<Product>> GetAll()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product?> GetById(int id)
        {
            return await _context.Products.FirstOrDefaultAsync(x=>x.Id == id);
        }

        public async Task<List<Product>> GetPaginated(int pageNumber, int pageSize)
        {
            return await _context.Products.Include(p=>p.ProductImages).Skip((pageNumber-1)*pageSize).Take(pageSize).ToListAsync();
        }
        public async Task<int> GetProductCount()
        {
            return await _context.Products.CountAsync();
        }
    }
}
