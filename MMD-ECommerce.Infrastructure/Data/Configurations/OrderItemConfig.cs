using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MMD_ECommerce.Data.Models.Orders;

namespace MMD_ECommerce.Infrastructure.Data.Configurations
{
    public class OrderItemConfig : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.HasOne(order => order.Product)
                   .WithMany(customer => customer.OrderItems)
                   .HasForeignKey(order => order.productID);
            builder.Property(o => o.Price).HasColumnType("decimal(18,3)");
        }
    }
}
