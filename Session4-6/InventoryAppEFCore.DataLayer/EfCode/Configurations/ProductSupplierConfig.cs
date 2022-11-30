using InventoryAppEFCore.DataLayer.EfClasses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InventoryAppEFCore.DataLayer.EfCode.Configurations
{
    internal class ProductSupplierConfig : IEntityTypeConfiguration<ProductSupplier>
    {
        public void Configure
            (EntityTypeBuilder<ProductSupplier> entity)
        {
            entity.HasKey(x => new { x.ProductId, x.SupplierId });
        }
    }
}