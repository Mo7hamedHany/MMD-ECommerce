using Microsoft.AspNetCore.Mvc;
using MMD_ECommerce.API.Bases;
using MMD_ECommerce.Core.Features.Basket.Command.Models;
using MMD_ECommerce.Core.Features.Basket.Query.Models;

namespace MMD_ECommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : AppControllerBase
    {

        [HttpPost]
        public async Task<ActionResult> Update([FromBody] UpdateBasketCommand command)
        {
            return NewResult(await Mediator.Send(command));
        }

        [HttpGet]
        public async Task<ActionResult> Get([FromQuery] string id)
        {
            return NewResult(await Mediator.Send(new GetBasketQuery(id)));
        }

        [HttpDelete]
        public async Task<ActionResult> Delete([FromQuery] string id)
        {
            return NewResult(await Mediator.Send(new DeleteBasketCommand(id)));
        }
    }
}
