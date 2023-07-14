using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlinePizzaSystemAPI.Enums;
using OnlinePizzaSystemAPI.Models;

namespace OnlinePizzaSystemAPI.Data.Config
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
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

            builder.Property(x => x.Position)
                .HasConversion(
                    x => x.ToString(),
                    x => (Position)Enum.Parse(typeof(Position), x)
                );

            builder.HasOne(x => x.Location)
                .WithMany(x => x.Employees)
                .HasForeignKey(x => x.LocationId)
                .IsRequired();

            builder.ToTable("Employees");
        }
    }

}
