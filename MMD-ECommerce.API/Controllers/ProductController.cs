using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MMD_ECommerce.API.Bases;
using MMD_ECommerce.API.Utility;
using MMD_ECommerce.Core.Features.Products.Command.Models;
using MMD_ECommerce.Core.Features.Products.Query.Models;
using System.Security.Claims;

namespace MMD_ECommerce.API.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class ProductController : AppControllerBase
    {


        [HttpGet]
        [Cash(60)]
        public async Task<ActionResult> GetProducts([FromQuery] GetProductsQuery query)
        {
            var products = await Mediator.Send(query);
            return Ok(products);
        }

        [HttpGet("id")]
        public async Task<ActionResult> GetProductById([FromQuery] int id)
        {
            var products = await Mediator.Send(new GetProductByIdQuery(id));
            return Ok(products);
        }

        [Authorize(Roles = "Merchant,Admin")]
        [HttpGet]
        public async Task<ActionResult> ProductsForMerchant()
        {
            var merchantEmail = User.FindFirstValue(ClaimTypes.Email);

            return Ok(await Mediator.Send(new GetProductsForMerchantQuery(merchantEmail)));
        }

        [Authorize(Roles = "Merchant")]
        [HttpGet]
        public async Task<ActionResult> MerchantPurchasedItems()
        {
            var merchantEmail = User.FindFirstValue(ClaimTypes.Email);

            return Ok(await Mediator.Send(new GetAmountOfMerchantSolds(merchantEmail)));
        }

        [Authorize(Roles = "Merchant,Admin")]
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateProductCommand command)
        {
            var merchantEmail = User.FindFirstValue(ClaimTypes.Email);
            command.MerchantEmail = merchantEmail;

            return NewResult(await Mediator.Send(command));
        }

        [Authorize(Roles = "Merchant,Admin")]
        [HttpPut]
        public async Task<ActionResult> EditProduct([FromBody] EditProductCommand command)
        {
            return NewResult(await Mediator.Send(command));
        }

        [Authorize(Roles = "Merchant,Admin")]
        [HttpDelete]
        public async Task<ActionResult> Delete([FromQuery] int id)
        {
            return NewResult(await Mediator.Send(new DeleteProductCommand(id)));
        }
    }
}
