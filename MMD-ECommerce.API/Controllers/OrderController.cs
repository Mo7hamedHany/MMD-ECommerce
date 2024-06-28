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

        private readonly ICsvExportService _csvExportService;
        private readonly IPdfExportService _pdfExportService;

        public OrderController(ICsvExportService csvExportService, IPdfExportService pdfExportService)
        {
            _csvExportService = csvExportService;
            _pdfExportService = pdfExportService;
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateOrderCommand command)
        {
            return NewResult(await Mediator.Send(command));
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult> OrdersForSpecificUser()
        {
            var email = User.FindFirstValue(ClaimTypes.Email);

            return Ok(await Mediator.Send(new GetOrdersForUserQuery(email)));
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<ActionResult> AllSystemOrders()
        {
            return Ok(await Mediator.Send(new GetAllOrdersQuery()));
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("export")]
        public async Task<ActionResult> DownloadOrdersCsv()
        {
            string csvContent = await _csvExportService.GenerateOrderCsvAsync();


            byte[] csvBytes = Encoding.UTF8.GetBytes(csvContent);


            return File(csvBytes, "text/csv", "system_orders.csv");
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("export-orders-pdf")]
        public async Task<IActionResult> ExportOrdersPdf()
        {
            var pdfBytes = await _pdfExportService.GenerateOrderPdfAsync();
            return File(pdfBytes, "application/pdf", "orders.pdf");
        }
    }
}
