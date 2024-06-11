using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MMD_ECommerce.Data.Models.Order;
using MMD_ECommerce.Data.Models.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMD_ECommerce.Infrastructure.Data.Configurations
{
    public class OrderConfig : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasMany(o => o.OrderItems).WithOne().OnDelete(DeleteBehavior.Cascade);

            builder.OwnsOne(o => o.ShippingAddress, o => o.WithOwner());

            builder.Property(o => o.SubTotal).HasColumnType("decimal(18,3)");

            builder.Property(x => x.paymentStatus).HasConversion<string>();
        }
    }
}
