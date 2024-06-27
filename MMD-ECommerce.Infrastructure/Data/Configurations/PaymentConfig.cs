using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MMD_ECommerce.Data.Models.Payments;

namespace MMD_ECommerce.Infrastructure.Data.Configurations
{
    public class PaymentConfig : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.Property(x => x.PaymentStatus).HasConversion<string>();
        }
    }
}
