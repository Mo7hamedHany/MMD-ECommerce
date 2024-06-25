using MMD_ECommerce.Data.Models.Basket;
using MMD_ECommerce.Data.Models.Products;
using MMD_ECommerce.Infrastructure.Repositories.Abstractions;
using MMD_ECommerce.Infrastructure.Specifications;
using MMD_ECommerce.Service.Abstractions;

namespace MMD_ECommerce.Service.Implementations
{
    public class BasketService : IBasketService
    {

        private readonly IBasketRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public BasketService(IBasketRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<string> DeleteBasketAsync(string id)
        {
            var basket = await _repository.GetCustomerBasketAsync(id);
            if (basket is null) return "NotFound";

            if (await _repository.DeleteCustomerBasketAsync(id)) return "Success";

            return "BadRequest";
        }

        public async Task<Basket?> GetBasketAsync(string id)
        {
            var basket = await _repository.GetCustomerBasketAsync(id);

            if (basket == null) return null;

            return basket;
        }

        public async Task<string?> UpdateBasketAsync(Basket basket)
        {
            foreach (var item in basket.BasketItems)
            {
                var specs = new ProductSpecifications(item.ProductId);
                var product = await _unitOfWork.Repository<Product, int>().GetWithSpecsAsync(specs);
                if (product == null) return "ProductNotFound";
                if (product != null)
                {
                    item.ProductName = product.Name;
                    item.Description = product.Description;
                    item.Price = product.Price;
                    item.PictureUrl = product.PictureUrl!;
                    item.TypeName = product.ProductType!.Name;
                    item.BrandName = product.ProductBrand!.Name;
                    item.CategoryName = product.Category!.Name;
                }
            }

            basket.CreatedAt = basket.UpdatedAt = DateTime.UtcNow;

            var updatedBasket = await _repository.UpdateCustomerBasketAsync(basket);

            return "Success";
        }

    }
}
