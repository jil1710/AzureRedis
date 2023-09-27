
namespace AzureRedis.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;

        public ProductService(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }

        public async Task<string?> GetProductById(int id)
        {
            var response = await _httpClient.GetStringAsync($"/products/{id}");

            if (response is not null)
            {
                return response;
            }

            return String.Empty;

         
        }
    }
}
