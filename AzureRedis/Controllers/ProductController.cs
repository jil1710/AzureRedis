using AzureRedis.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AzureRedis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService) 
        {
            this._productService = productService;
        }
        [HttpGet]
        public async Task<string?> GetProductById(int id = 1)
        {
            return await _productService.GetProductById(id);
        }
    }
}
