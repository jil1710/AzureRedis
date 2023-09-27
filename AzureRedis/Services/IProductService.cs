namespace AzureRedis.Services
{
    public interface IProductService
    {
        Task<string?> GetProductById(int id);
    }
}