using MMD_ECommerce.Data.Models.Order.Order;
using MMD_ECommerce.Data.Models.Products;
using MMD_ECommerce.Infrastructure.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MMD_ECommerce.Infrastructure.Data.DataSeeding
{
    public static class DataContextSeed
    {
        public static async Task SeedData(MMDDataContext context)
        {
            if (!context.Set<ProductBrand>().Any())
            {

                var brandsData = await File.ReadAllTextAsync("../MMD-ECommerce.Infrastructure/Data/DataSeeding/Brands.json");

                var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);

                if (brands != null && brands.Any())
                {
                    await context.Set<ProductBrand>().AddRangeAsync(brands);
                    await context.SaveChangesAsync();
                }
            }

            if (!context.Set<ProductType>().Any())
            {

                var TypesData = await File.ReadAllTextAsync("../MMD-ECommerce.Infrastructure/Data/DataSeeding/Types.json");

                var Types = JsonSerializer.Deserialize<List<ProductType>>(TypesData);

                if (Types != null && Types.Any())
                {
                    await context.Set<ProductType>().AddRangeAsync(Types);
                    await context.SaveChangesAsync();
                }
            }

            if (!context.Set<Category>().Any())
            {

                var categoryData = await File.ReadAllTextAsync("../MMD-ECommerce.Infrastructure/Data/DataSeeding/Categories.json");

                var categories = JsonSerializer.Deserialize<List<Category>>(categoryData);

                if (categories != null && categories.Any())
                {
                    await context.Set<Category>().AddRangeAsync(categories);
                    await context.SaveChangesAsync();
                }
            }

            if (!context.Set<Product>().Any())
            {

                var productsData = await File.ReadAllTextAsync("../MMD-ECommerce.Infrastructure/Data/DataSeeding/Products.json");

                var products = JsonSerializer.Deserialize<List<Product>>(productsData);

                if (products != null && products.Any())
                {
                    await context.Set<Product>().AddRangeAsync(products);
                    await context.SaveChangesAsync();
                }
            }

            if (!context.Set<DeliveryMethods>().Any())
            {

                var deliverData = await File.ReadAllTextAsync("../MMD-ECommerce.Infrastructure/Data/DataSeeding/delivery.json");

                var deliveries = JsonSerializer.Deserialize<List<DeliveryMethods>>(deliverData);

                if (deliveries != null && deliveries.Any())
                {
                    await context.Set<DeliveryMethods>().AddRangeAsync(deliveries);
                    await context.SaveChangesAsync();
                }
            }

        }
        }
}
