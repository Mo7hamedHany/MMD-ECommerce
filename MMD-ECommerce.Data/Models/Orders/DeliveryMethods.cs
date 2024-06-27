using MMD_ECommerce.Data.Bases;

namespace MMD_ECommerce.Data.Models.Orders
{
    public class DeliveryMethods : ModelKey<int>
    {
        public string ShortName { get; set; }

        public string Description { get; set; }

        public string DeliveryTime { get; set; }

        public decimal Price { get; set; }
    }
}
