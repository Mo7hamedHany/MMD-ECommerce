using Microsoft.AspNetCore.Identity;
using MMD_ECommerce.Data.Models.Users;
using MMD_ECommerce.Service.Abstractions;
using MMD_ECommerce.Service.HelperModels;

namespace MMD_ECommerce.Service.Implementations
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<string> CreateMerchantAsync(AuthenticationHM create)
        {
            var user = await _userManager.FindByEmailAsync(create.Email);
            if (user is not null) return "Exist";

            var appUser = new AppUser
            {
                Email = create.Email,
                UserName = create.Email,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
            };
            var result = await _userManager.CreateAsync(appUser, create.Password);
            if (!result.Succeeded) return "Fail";

            var roleAssignmentResult = await _userManager.AddToRoleAsync(appUser, "Merchant");
            if (!roleAssignmentResult.Succeeded) return "Error";

            return "Success";
        }

        public async Task<string> DeleteUserAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user is null) return "Not Exist";

            var isAdmin = await _userManager.IsInRoleAsync(user, "Admin");
            if (isAdmin)
            {
                return "CannotDeleteAdmin";
            }

            var result = await _userManager.DeleteAsync(user);
            if (!result.Succeeded) return "Error";

            return "Success";

        }

        public async Task<IEnumerable<UserHM?>> GetAllBasedOnRoleAsync(string role)
        {
            var users = await _userManager.GetUsersInRoleAsync(role);

            if (users == null) return Enumerable.Empty<UserHM>();

            return users.Select(user => new UserHM
            {
                UserName = user.UserName,
                Email = user.Email,
                Role = role
            });
        }

        public async Task<string> LoginAsync(AuthenticationHM login)
        {
            var user = await _userManager.FindByEmailAsync(login.Email);

            if (user is null) return "Not Found";

            var result = await _signInManager.CheckPasswordSignInAsync(user, login.Password, false);

            if (result.Succeeded)
                return "Success";

            return "Bad Request";
        }

        public async Task<string> RegisterAsync(AuthenticationHM register)
        {

            var user = await _userManager.FindByEmailAsync(register.Email);
            if (user is not null) return "Exist";

            var appUser = new AppUser
            {
                Email = register.Email,
                UserName = register.Email,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };
            var result = await _userManager.CreateAsync(appUser, register.Password);
            if (!result.Succeeded) return "Fail";

            var roleAssignmentResult = await _userManager.AddToRoleAsync(appUser, "Client");
            if (!roleAssignmentResult.Succeeded) return "Error";

            return "Success";
        }
    }
}
