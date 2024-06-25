using MMD_ECommerce.Data.Bases;

namespace MMD_ECommerce.Data.Models.Products
{
    public class ProductType :  ModelKey<int>, ITimeTrackEntity
    {
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}