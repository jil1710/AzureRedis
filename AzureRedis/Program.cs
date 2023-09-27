using AzureRedis.Services;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;

namespace AzureRedis
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddStackExchangeRedisCache(option =>
            {
                option.Configuration = builder.Configuration.GetConnectionString("AzureRedisCache");
                option.InstanceName = "master";
            });
            builder.Services.AddScoped<ProductService>();
            builder.Services.AddScoped<IProductService>(provider =>
            {
                var cache = provider.GetService<ProductService>()!;

                return new ProductCacheService(cache, provider.GetService<IDistributedCache>()!);
            });

            builder.Services.AddHttpClient<ProductService>(options =>
            {
                options.BaseAddress = new Uri("https://dummyjson.com");
            });

            var app = builder.Build();

            

            app.UseHttpsRedirection();

            app.MapControllers();

            app.Run();
        }
    }
}