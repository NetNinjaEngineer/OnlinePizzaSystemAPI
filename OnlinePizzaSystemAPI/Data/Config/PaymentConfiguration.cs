using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using OnlinePizzaSystemAPI.Models;
using OnlinePizzaSystemAPI.Enums;

namespace OnlinePizzaSystemAPI.Data.Config
{
    public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();
            builder.Property(x => x.PaymentAmount)
                .HasPrecision(18, 2)
                .IsRequired();

            builder.Property(x => x.PaymentMethod)
                .HasConversion(
                    x => x.ToString(),
                    x => (PaymentMethod)Enum.Parse(typeof(PaymentMethod), x)
                );

            builder.HasOne(x => x.Customer)
                .WithOne(x => x.Payment)
                .HasForeignKey<Payment>(x => x.CustomerId)
                .IsRequired();

            builder.ToTable("Payments");
        }
    }
}
