using MMD_ECommerce.Data.Models.Orders;
using System.Text;

namespace MMD_ECommerce.Service.HelperModels
{
    public class CsvGenerator
    {
        public string GenerateCsv(List<Order> orders)
        {
            var sb = new StringBuilder();
            sb.AppendLine("OrderId, BuyerEmail, OrderDate, ProductId, ProductName, Quantity, Price, Total");

            foreach (var order in orders)
            {
                foreach (var item in order.OrderItems)
                {
                    sb.AppendLine($"{order.Id}, {order.BuyerEmail}, {order.OrderDate}, {item.Product.Id}, {item.Product.Name}, {item.Quantity}, {item.Price}, {item.Price * item.Quantity}");
                }
            }

            return sb.ToString();
        }

        public void SaveCsvToFile(string csvContent, string filePath)
        {
            File.WriteAllText(filePath, csvContent);
        }
    }
}
