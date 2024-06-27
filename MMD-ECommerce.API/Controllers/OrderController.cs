using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MMD_ECommerce.API.Bases;
using MMD_ECommerce.Core.Features.Orders.Command.Models;
using MMD_ECommerce.Core.Features.Orders.Query.Models;
using MMD_ECommerce.Service.Abstractions;
using System.Security.Claims;
using System.Text;

namespace MMD_ECommerce.API.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class OrderController : AppControllerBase
    {

        private ICsvExportService _csvExportService;

        public OrderController(ICsvExportService csvExportService)
        {
            _csvExportService = csvExportService;
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateOrderCommand command)
        {
            return NewResult(await Mediator.Send(command));
        }

        [HttpGet]
        public async Task<ActionResult> DeliveryMethods()
        {
            return Ok(await Mediator.Send(new GetDeliveryMethodsQuery()));
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult> GetOrdersForUser()
        {
            var userEmail = User.FindFirstValue(ClaimTypes.Email);

            return Ok(await Mediator.Send(new GetOrdersForUserQuery(userEmail)));
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<ActionResult> GetAllOrders()
        {
            return Ok(await Mediator.Send(new GetAllOrdersQuery()));
        }


        [HttpGet("export")]
        public async Task<IActionResult> ExportOrders()
        {
            string csvContent = await _csvExportService.GenerateOrderCsvAsync();


            byte[] csvBytes = Encoding.UTF8.GetBytes(csvContent);


            return File(csvBytes, "text/csv", "system_orders.csv");
        }
    }
}
