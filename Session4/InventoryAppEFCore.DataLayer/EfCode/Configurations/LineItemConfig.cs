using InventoryAppEFCore.DataLayer.EfClasses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InventoryAppEFCore.DataLayer.EfCode.Configurations
{
    internal class LineItemConfig : IEntityTypeConfiguration<LineItem>
    {
        public void Configure
            (EntityTypeBuilder<LineItem> entity)
        {
            entity.HasOne(p => p.SelectedProduct)
                .WithMany();
        }
    }
}
