using MMD_ECommerce.Data.Models.Basket;

namespace MMD_ECommerce.Service.Abstractions
{
    public interface IBasketService
    {
        Task<Basket?> GetBasketAsync(string id);

        Task<string?> UpdateBasketAsync(Basket basket);

        Task<string> DeleteBasketAsync(string id);
    }
}
