using Microsoft.AspNetCore.Identity;
using MMD_ECommerce.Data.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMD_ECommerce.Data.Models.Users
{
    public class AppUser : IdentityUser, ITimeTrackEntity
    {
        public Address Address { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
