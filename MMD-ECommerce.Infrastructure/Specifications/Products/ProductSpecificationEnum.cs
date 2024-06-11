using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MMD_ECommerce.Infrastructure.Specifications
{
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public enum ProductSpecificationEnum
        {
            NameAsc, NameDesc, PriceAsc, PriceDesc,
        }
    
}
