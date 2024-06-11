using MMD_ECommerce.Data.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMD_ECommerce.Service.Abstractions
{
    public interface ITokenService
    {
        Task<string> GetToken(AppUser user);
    }
}
