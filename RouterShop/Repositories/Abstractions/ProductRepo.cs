using Microsoft.EntityFrameworkCore;
using RouterShop.Context;
using RouterShop.Models;
using RouterShop.Models.DTO;
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

        public async Task<List<Product>> GetPaginated(ProductFilterDto filter)
        {
            var query = _context.Products.AsQueryable();
            if (!string.IsNullOrEmpty(filter.SearchQuery))
            {
                query = query.Where(p => p.Name.Contains(filter.SearchQuery) || p.Description.Contains(filter.SearchQuery));
            }
            if (filter.CategoryId.HasValue)
            {
                query = query.Where(p => p.CategoryId == filter.CategoryId.Value);
            }
            if(filter.MinPrice.HasValue)
            {
                query = query.Where(p => p.Price >= filter.MinPrice.Value);
            }
            if(filter.MaxPrice.HasValue)
            {
                query = query.Where(p => p.Price <= filter.MaxPrice.Value);
            }
            var items = await query
                .Skip((filter.PageNumber - 1) * filter.PageSize)
                .Take(filter.PageSize)
                .ToListAsync();
            return items;
        }
        public async Task<int> GetProductCount()
        {
            return await _context.Products.CountAsync();
        }
    }
}
