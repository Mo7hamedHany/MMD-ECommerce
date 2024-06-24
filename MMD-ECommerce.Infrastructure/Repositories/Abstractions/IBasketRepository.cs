using MMD_ECommerce.Data.Models.Basket;

namespace MMD_ECommerce.Infrastructure.Repositories.Abstractions
{
    public interface IBasketRepository
    {
        Task<Basket?> GetCustomerBasketAsync(string id);

        Task<Basket?> UpdateCustomerBasketAsync(Basket basket);

        Task<bool> DeleteCustomerBasketAsync(string id);
    }
}
