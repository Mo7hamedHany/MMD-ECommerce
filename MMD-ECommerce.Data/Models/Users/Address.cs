using MMD_ECommerce.Data.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMD_ECommerce.Data.Models.Users
{
    public class Address : ModelKey<int>
    {
        public string Street { get; set; }

        public string State { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public string PostalCode { get; set; }

        public AppUser AppUser { get; set; }

        public string AppUserId { get; set; }
    }
}
