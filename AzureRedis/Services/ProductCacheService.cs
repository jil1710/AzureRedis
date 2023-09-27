using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;

namespace AzureRedis.Services
{
    public class ProductCacheService : IProductService
    {
        private readonly ProductService productService;
        private readonly IDistributedCache memoryCache;

        public ProductCacheService(ProductService productService, IDistributedCache memoryCache)
        {
            this.productService = productService;
            this.memoryCache = memoryCache;
        }
        public async Task<string?> GetProductById(int id)
        {
            string key = $"product-{id}";
            var data = memoryCache.GetString(key);
            if(string.IsNullOrEmpty(data))
            {
                var res = await productService.GetProductById(id);
                if (!string.IsNullOrEmpty(res))
                {
                    memoryCache.SetString(key, res, options: new DistributedCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(5)));
                    return res;
                }

            }
            return data;
        }
    }
}
