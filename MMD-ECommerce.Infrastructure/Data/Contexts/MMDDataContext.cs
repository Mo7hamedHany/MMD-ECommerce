using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MMD_ECommerce.Data.Models;
using MMD_ECommerce.Data.Models.Order;
using MMD_ECommerce.Data.Models.Orders;
using MMD_ECommerce.Data.Models.Products;
using MMD_ECommerce.Data.Models.Users;
using MMD_ECommerce.Infrastructure.Data.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MMD_ECommerce.Infrastructure.Data.Contexts
{
    public class MMDDataContext : IdentityDbContext<AppUser>
    {

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        public MMDDataContext(DbContextOptions<MMDDataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
