using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RouterShop.Services.Interfaces;

namespace RouterShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private const int pageSize = 10;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public async Task<IActionResult> GetProducts([FromQuery] int pageNumber = 1)
        {
            var products = await _productService.GetProductsPaginated(pageNumber, pageSize);
            return Ok(products);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await _productService.GetById(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
        [HttpGet("allProducts")]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _productService.GetAll();
            return Ok(products);
        }
    }
}
