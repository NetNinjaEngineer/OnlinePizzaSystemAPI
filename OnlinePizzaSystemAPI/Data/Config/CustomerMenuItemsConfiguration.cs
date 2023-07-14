using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlinePizzaSystemAPI.Models;

namespace OnlinePizzaSystemAPI.Data.Config
{
    public class CustomerMenuItemsConfiguration : IEntityTypeConfiguration<CustomerMenuItems>
    {
        public void Configure(EntityTypeBuilder<CustomerMenuItems> builder)
        {
            builder.HasKey(x => new { x.CustomerId, x.MenuItemId });
            builder.ToTable("CustomerMenuItems");
        }
    }

}
