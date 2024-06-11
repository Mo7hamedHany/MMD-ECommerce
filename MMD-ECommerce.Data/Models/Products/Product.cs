﻿using MMD_ECommerce.Data.Bases;
using MMD_ECommerce.Data.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMD_ECommerce.Data.Models.Products
{
    public class Product : ModelKey<int>, IBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string? PictureUrl { get; set; }
        public decimal Price { get; set; }
        public ProductBrand? ProductBrand { get; set; }
        public int BrandId { get; set; }
        public ProductType? ProductType { get; set; }
        public int TypeId { get; set; }
        public Category? Category { get; set; }
        public int CategoryId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}