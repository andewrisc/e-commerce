using System;
using System.Reflection;
using System.Text.Json;
using Core.Entities;

namespace Infrastructure.Data;

public class StoreContextSeed
{
    public static async Task SeedAsync(StoreContext context)
    {
        var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        
        if (!context.Products.Any())
        {
            var productData = await File
                .ReadAllBytesAsync( path + @"/Data/SeedData/products.json");

            var products = JsonSerializer.Deserialize<List<Product>>(productData);

            if (products == null) return;

            context.Products.AddRange(products);

            await context.SaveChangesAsync();
        }

        if (!context.DeliveryMethods.Any())
        {
            var dmData = await File.ReadAllBytesAsync(path + @"/Data/SeedData/delivery.json");

            var deliveries = JsonSerializer.Deserialize<List<DeliveryMethod>>(dmData);

            if (deliveries == null) return;

            context.DeliveryMethods.AddRange(deliveries);

            await context.SaveChangesAsync();
        }
    }
}
