using MMD_ECommerce.Service.HelperModels;

namespace MMD_ECommerce.Service.Abstractions
{
    public interface IAccountService
    {
        Task<string> RegisterAsync(AuthenticationHM register);
        Task<string> LoginAsync(AuthenticationHM login);
        Task<string> CreateMerchantAsync(AuthenticationHM create);
        Task<string> DeleteUserAsync(string email);
        Task<IEnumerable<UserHM?>> GetAllBasedOnRoleAsync(string role);
    }
}
