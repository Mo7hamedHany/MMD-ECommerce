namespace MMD_ECommerce.Service.Abstractions
{
    public interface IPdfExportService
    {
        Task<byte[]> GenerateOrderPdfAsync();
    }
}
