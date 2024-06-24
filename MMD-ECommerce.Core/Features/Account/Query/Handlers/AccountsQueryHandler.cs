using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using MMD_ECommerce.Core.Bases;
using MMD_ECommerce.Core.DTOs.Account;
using MMD_ECommerce.Core.Features.Account.Query.Models;
using MMD_ECommerce.Data.Models.Users;
using MMD_ECommerce.Service.Abstractions;

namespace MMD_ECommerce.Core.Features.Account.Query.Handlers
{
    public class AccountsQueryHandler : ResponseHandler, IRequestHandler<GetAccountsQuery, Response<IEnumerable<UserDto>>>
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;

        public AccountsQueryHandler(RoleManager<IdentityRole> roleManager, UserManager<AppUser> userManager, IMapper mapper, IAccountService accountService)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _mapper = mapper;
            _accountService = accountService;
        }

        public async Task<Response<IEnumerable<UserDto>>> Handle(GetAccountsQuery request, CancellationToken cancellationToken)
        {
            var roleExists = await _roleManager.RoleExistsAsync(request.Role);
            if (!roleExists) return BadRequest<IEnumerable<UserDto>>("Role does not exist.");


            var users = await _accountService.GetAllBasedOnRoleAsync(request.Role);
            if (users == null || !users.Any()) return NotFound<IEnumerable<UserDto>>("No users found for this role.");

            // Map users to UserDto
            var userDtos = _mapper.Map<IEnumerable<UserDto>>(users);

            return Success(userDtos);
        }
    }
}
