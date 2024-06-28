using DinkToPdf;
using DinkToPdf.Contracts;
using MMD_ECommerce.Data.Models.Orders;
using MMD_ECommerce.Infrastructure.Repositories.Abstractions;
using MMD_ECommerce.Infrastructure.Specifications.Orders;
using MMD_ECommerce.Service.Abstractions;
using System.Text;

namespace MMD_ECommerce.Service.Implementations
{
    public class PdfExportService : IPdfExportService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConverter _converter;

        public PdfExportService(IUnitOfWork unitOfWork, IConverter converter)
        {
            _unitOfWork = unitOfWork;
            _converter = converter;
        }

        public async Task<byte[]> GenerateOrderPdfAsync()
        {
            var specs = new OrderSpecifications();
            var orders = await _unitOfWork.Repository<Order, Guid>().GetAllWithSpecsAsync(specs);

            var html = new StringBuilder();
            html.Append("<html><head><style>table { width: 100%; border-collapse: collapse; } table, th, td { border: 1px solid black; padding: 8px; text-align: left; } th { background-color: #f2f2f2; }</style></head><body>");
            html.Append("<h1>All Orders</h1>");
            html.Append("<table><tr><th>OrderID</th><th>BuyerEmail</th><th>OrderDate</th><th>TotalAmount</th></tr>");

            foreach (var order in orders)
            {
                html.Append($"<tr><td>{order.Id}</td><td>{order.BuyerEmail}</td><td>{order.OrderDate}</td><td>{order.Total()}</td></tr>");
            }

            html.Append("</table></body></html>");

            var doc = new HtmlToPdfDocument()
            {
                GlobalSettings = {
                    PaperSize = PaperKind.A4,
                    Orientation = Orientation.Portrait
                },
                Objects = {
                    new ObjectSettings() {
                        HtmlContent = html.ToString(),
                        WebSettings = { DefaultEncoding = "utf-8" }
                    }
                }
            };

            return _converter.Convert(doc);
        }
    }
}
