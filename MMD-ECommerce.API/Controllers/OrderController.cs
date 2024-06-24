using Microsoft.AspNetCore.Mvc;
using MMD_ECommerce.API.Bases;
using MMD_ECommerce.Core.Features.Orders.Command.Models;

namespace MMD_ECommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : AppControllerBase
    {

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateOrderCommand command)
        {
            return NewResult(await Mediator.Send(command));
        }
    }
}
