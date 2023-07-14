using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlinePizzaSystemAPI.Models;

namespace OnlinePizzaSystemAPI.Data.Config
{
    public class IngredientConfiguration : IEntityTypeConfiguration<Ingredient>
    {
        public void Configure(EntityTypeBuilder<Ingredient> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();

            builder.Property(x => x.Name)
                .HasColumnType("VARCHAR")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.Cost)
                .HasPrecision(15, 2)
                .IsRequired();

            builder.HasOne(x => x.Supplier)
                .WithMany(x => x.Ingredients)
                .HasForeignKey(x => x.SupplierId)
                .IsRequired();

            builder.ToTable("Ingredients");
        }
    }

}
