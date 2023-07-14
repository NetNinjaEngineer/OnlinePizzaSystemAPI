using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlinePizzaSystemAPI.Models;

namespace OnlinePizzaSystemAPI.Data.Config
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();

            builder.Property(x => x.Name)
                .HasColumnType("VARCHAR")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.DeliveryAddress)
               .HasColumnType("VARCHAR")
               .HasMaxLength(150)
               .IsRequired();

            builder.Property(x => x.Email)
                 .HasColumnType("VARCHAR")
                 .HasMaxLength(100)
                 .IsRequired();

            builder.HasMany(x => x.MenuItems)
                .WithMany(x => x.Customers)
                .UsingEntity<CustomerMenuItems>();

            builder.ToTable("Customers");
        }
    }

}
