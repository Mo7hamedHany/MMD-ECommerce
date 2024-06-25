using MMD_ECommerce.Data.Models.Basket;
using MMD_ECommerce.Infrastructure.Repositories.Abstractions;
using StackExchange.Redis;
using System.Text.Json;

namespace MMD_ECommerce.Infrastructure.Repositories.Implementations
{
    public class BasketRepository : IBasketRepository
    {

        private readonly IDatabase _database;

        public BasketRepository(IConnectionMultiplexer connection)
        {
            _database = connection.GetDatabase();
        }

        public async Task<bool> DeleteCustomerBasketAsync(string id)
             => await _database.KeyDeleteAsync(id);

        public async Task<Basket?> GetCustomerBasketAsync(string id)
        {
            var basket = await _database.StringGetAsync(id);

            return basket.IsNullOrEmpty ? null : JsonSerializer.Deserialize<Basket>(basket);
        }

        public async Task<Basket?> UpdateCustomerBasketAsync(Basket basket)
        {
            var serializedBasket = JsonSerializer.Serialize(basket);

            var result = await _database.StringSetAsync(basket.Id, serializedBasket, TimeSpan.FromDays(7));

            return result ? await GetCustomerBasketAsync(basket.Id) : null;
        }
    }
}
