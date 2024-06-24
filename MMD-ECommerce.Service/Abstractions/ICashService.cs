namespace MMD_ECommerce.Service.Abstractions
{
    public interface ICashService
    {
        Task<string?> GetCashResponseAsync(string key);
        Task SetCashResponseAsync(string key, object response, TimeSpan time);
    }
}
