using MMD_ECommerce.Data.Models.Orders;
using MMD_ECommerce.Infrastructure.Repositories.Abstractions;
using MMD_ECommerce.Service.Abstractions;
using System.Text;

namespace MMD_ECommerce.Service.Implementations
{
    public class CsvExportService : ICsvExportService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CsvExportService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<string> GenerateOrderCsvAsync()
        {
            var orders = await _unitOfWork.Repository<Order, Guid>().GetAllAsync();

            var csvBuilder = new StringBuilder();
            csvBuilder.AppendLine("OrderID,BuyerEmail,OrderDate");

            foreach (var order in orders)
            {
                csvBuilder.AppendLine($"{order.Id},{order.BuyerEmail},{order.OrderDate}");
            }

            return csvBuilder.ToString();
        }
    }
}
