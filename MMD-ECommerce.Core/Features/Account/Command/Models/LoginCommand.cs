﻿using MediatR;
using MMD_ECommerce.Core.Bases;
using MMD_ECommerce.Core.DTOs.Account;

namespace MMD_ECommerce.Core.Features.Account.Command.Models
{
    public class LoginCommand : AuthenticationDto, IRequest<Response<string>>
    {
    }
}
