using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlinePizzaSystemAPI.Models;

namespace OnlinePizzaSystemAPI.Data.Config
{
    public class DeliveryDriverConfiguration : IEntityTypeConfiguration<DeliveryDriver>
    {
        public void Configure(EntityTypeBuilder<DeliveryDriver> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();

            builder.Property(x => x.Name)
                .HasColumnType("VARCHAR")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.PhoneNumber)
                .HasColumnType("VARCHAR")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.VehicleInformation)
               .HasColumnType("VARCHAR")
               .HasMaxLength(250)
               .IsRequired();

            builder.HasOne(x => x.Store)
                .WithMany(x => x.DeliveryDrivers)
                .HasForeignKey(x => x.StoreId)
                .IsRequired();

            builder.ToTable("DeliveryDrivers");
        }
    }

}
