using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MMD_ECommerce.API.Bases;
using MMD_ECommerce.Core.Features.Account.Command.Models;
using MMD_ECommerce.Core.Features.Account.Query.Models;

namespace MMD_ECommerce.API.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class AccountController : AppControllerBase
    {

        [HttpPost]
        public async Task<ActionResult> Login([FromBody] LoginCommand command)
            => NewResult(await Mediator.Send(command));


        [HttpPost]
        public async Task<ActionResult> Register([FromBody] RegisterCommand command)
            => NewResult(await Mediator.Send(command));


        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult> CreateMerchant([FromBody] CreateMerchantCommand command)
            => NewResult(await Mediator.Send(command));


        [Authorize(Roles = "Admin")]
        [HttpDelete]
        public async Task<ActionResult> DeleteUser([FromBody] DeleteUserCommand command)
            => NewResult(await Mediator.Send(command));

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<ActionResult> GetUsers([FromQuery] string role)
        {
            return NewResult(await Mediator.Send(new GetAccountsQuery(role)));
        }
    }
}
