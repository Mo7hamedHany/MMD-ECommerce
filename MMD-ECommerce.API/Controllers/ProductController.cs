using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MMD_ECommerce.Core.Features.Products.Query.Models;
using MMD_ECommerce.Infrastructure.Specifications.Products;

namespace MMD_ECommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult> GetProducts([FromQuery] GetProductsQuery query)
        {
            var products = await _mediator.Send(query);
            return Ok(products);
        }
    }
}
