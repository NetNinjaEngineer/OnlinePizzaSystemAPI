using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlinePizzaSystemAPI.Models;

namespace OnlinePizzaSystemAPI.Data.Config
{
    public class CouponConfiguration : IEntityTypeConfiguration<Coupon>
    {
        public void Configure(EntityTypeBuilder<Coupon> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();

            builder.Property(x => x.Code)
                .HasColumnType("VARCHAR")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.DiscountAmount)
                .HasPrecision(15, 2)
                .IsRequired();

            builder.Property(x => x.ExpirationDate)
                .HasColumnType("datetime")
                .IsRequired();

            builder.Property(x => x.UsageCount)
                .IsRequired();

            builder.HasOne(x => x.Customer)
                .WithOne(x => x.Coupon)
                .HasForeignKey<Coupon>(x => x.CustomerId)
                .IsRequired();

            builder.ToTable("Coupons");
        }
    }

}
