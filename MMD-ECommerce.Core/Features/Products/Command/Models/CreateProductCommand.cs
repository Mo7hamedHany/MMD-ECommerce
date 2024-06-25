using MediatR;
using MMD_ECommerce.Core.Bases;
using MMD_ECommerce.Core.DTOs.Product;
using System.Text.Json.Serialization;

namespace MMD_ECommerce.Core.Features.Products.Command.Models
{
    public class CreateProductCommand : ProductToCreateDto, IRequest<Response<string>>
    {
        [JsonIgnore]
        public string? MerchantEmail { get; set; }
    }
}
