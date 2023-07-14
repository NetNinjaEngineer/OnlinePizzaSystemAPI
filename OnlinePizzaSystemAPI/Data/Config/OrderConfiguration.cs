using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using OnlinePizzaSystemAPI.Models;
using OnlinePizzaSystemAPI.Enums;

namespace OnlinePizzaSystemAPI.Data.Config
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();

            builder.Property(x => x.OrderTime)
                .HasColumnType("datetime")
                .IsRequired();

            builder.Property(x => x.OrderTime)
                .HasColumnType("time")
                .IsRequired();

            builder.Property(x => x.TotalCost)
                .HasPrecision(18, 2)
                .IsRequired();

            builder.HasOne(x => x.Customer)
                .WithMany(x => x.Orders)
                .HasForeignKey(x => x.CustomerId)
                .IsRequired();

            builder.HasOne(x => x.DeliveryDriver)
                .WithMany(x => x.Orders)
                .HasForeignKey(x => x.DeliveryDriverId)
                .IsRequired();

            builder.Property(x => x.DeliveryOptions)
                .HasConversion(
                    x => x.ToString(),
                    x => (DeliveryOptions)Enum.Parse(typeof(DeliveryOptions), x)
                );

            builder.ToTable("Orders");
        }
    }
}
