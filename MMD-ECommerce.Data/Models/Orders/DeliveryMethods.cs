using MMD_ECommerce.Data.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMD_ECommerce.Data.Models.Order.Order
{
    public class DeliveryMethods : ModelKey<int>
    {
        public string ShortName { get; set; }

        public string Description { get; set; }

        public string DeliveryTime { get; set; }

        public decimal Price { get; set; }
    }
}
