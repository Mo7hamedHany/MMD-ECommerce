using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using MMD_ECommerce.Core.Bases;
using MMD_ECommerce.Core.Features.Account.Command.Models;
using MMD_ECommerce.Data.Models.Users;
using MMD_ECommerce.Service.Abstractions;
using MMD_ECommerce.Service.HelperModels;

namespace MMD_ECommerce.Core.Features.Account.Command.Handlers
{
    public class LoginCommandHandler : ResponseHandler,
        IRequestHandler<LoginCommand, Response<string>>,
        IRequestHandler<RegisterCommand, Response<string>>,
        IRequestHandler<CreateMerchantCommand, Response<string>>,
        IRequestHandler<DeleteUserCommand, Response<string>>
    {

        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;
        private readonly ITokenService _tokenService;
        private readonly UserManager<AppUser> _userManager;

        public LoginCommandHandler(IAccountService accountService, IMapper mapper, ITokenService tokenService, UserManager<AppUser> userManager)
        {
            _accountService = accountService;
            _mapper = mapper;
            _tokenService = tokenService;
            _userManager = userManager;
        }

        public async Task<Response<string>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);

            var mappingResult = _mapper.Map<AuthenticationHM>(request);

            var loginResult = await _accountService.LoginAsync(mappingResult);

            switch (loginResult)
            {
                case "Not Found": return NotFound<string>("Email is not Correct");
                case "Success": return Success(await _tokenService.GetToken(user));
                case "Bad Request": return BadRequest<string>("Password is not correct");
                default: return BadRequest<string>("Something Went wrong please try again");
            }

        }

        public async Task<Response<string>> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var mappingResult = _mapper.Map<AuthenticationHM>(request);

            var registerResult = await _accountService.RegisterAsync(mappingResult);

            var user = await _userManager.FindByEmailAsync(request.Email);

            switch (registerResult)
            {
                case "Exist": return BadRequest<string>("This email Already Exists");
                case "Fail": return BadRequest<string>("Something Went wrong please try again");
                case "Error": return NotFound<string>("Role not found");
                case "Success": return Success(await _tokenService.GetToken(user));
                default: return BadRequest<string>("Error");
            }
        }

        public async Task<Response<string>> Handle(CreateMerchantCommand request, CancellationToken cancellationToken)
        {
            var mappingResult = _mapper.Map<AuthenticationHM>(request);

            var registerResult = await _accountService.CreateMerchantAsync(mappingResult);

            var user = await _userManager.FindByEmailAsync(request.Email);

            switch (registerResult)
            {
                case "Exist": return BadRequest<string>("This email Already Exists");
                case "Fail": return BadRequest<string>("Something Went wrong please try again");
                case "Error": return NotFound<string>("Role not found");
                case "Success": return Success(await _tokenService.GetToken(user));
                default: return BadRequest<string>("Error");
            }
        }

        public async Task<Response<string>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var deletionResult = await _accountService.DeleteUserAsync(request.Email);

            switch (deletionResult)
            {
                case "Not Exist": return NotFound<string>("User does not Exist");
                case "CannotDeleteAdmin": return UnprocessableEntity<string>("You Cannot Delete an Admin");
                case "Success": return Deleted<string>("User Deleted Successfully");
                default: return BadRequest<string>("Something Went wrong please try again");
            }
        }
    }
}

