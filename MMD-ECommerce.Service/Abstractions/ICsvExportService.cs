namespace MMD_ECommerce.Service.Abstractions
{
    public interface ICsvExportService
    {
        Task<string> GenerateOrderCsvAsync();
    }
}
