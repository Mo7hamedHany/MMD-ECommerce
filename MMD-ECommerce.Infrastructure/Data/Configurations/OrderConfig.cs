using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using MMD_ECommerce.Data.Models.Orders;
using MMD_ECommerce.Data.Models.Payments;

namespace MMD_ECommerce.Infrastructure.Data.Configurations
{
    public class OrderConfig : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasMany(o => o.OrderItems).WithOne().OnDelete(DeleteBehavior.Cascade);

            builder.OwnsOne(o => o.ShippingAddress, o => o.WithOwner());

            builder.HasOne(o => o.Payment)
                  .WithOne(p => p.Order)
                  .HasForeignKey<Payment>(p => p.OrderId);

            builder.Property(o => o.SubTotal).HasColumnType("decimal(18,3)");

            builder.Property(x => x.paymentStatus).HasConversion<string>();
        }
    }
}
