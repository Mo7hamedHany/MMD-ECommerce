using MMD_ECommerce.Data.Bases;
using MMD_ECommerce.Data.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMD_ECommerce.Data.Models.Products
{
    public class Category : ModelKey<int>, ITimeTrackEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get ; set ; }
        public DateTime UpdatedAt { get; set; }

        public List<Product> Products { get; set; }
    }
}
