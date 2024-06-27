using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MMD_ECommerce.Data.Models.Orders;
using MMD_ECommerce.Data.Models.Payments;
using MMD_ECommerce.Data.Models.Products;
using MMD_ECommerce.Data.Models.Users;
using System.Reflection;

namespace MMD_ECommerce.Infrastructure.Data.Contexts
{
    public class MMDDataContext : IdentityDbContext<AppUser>
    {

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Payment> Payments { get; set; }

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
