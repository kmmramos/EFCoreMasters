using InventoryAppEFCore.DataLayer.EfClasses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace InventoryAppEFCore.DataLayer.EfCode.Configurations
{
    internal class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure
            (EntityTypeBuilder<Product> entity)
        {
            entity.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(50);

            entity.HasOne(p => p.Promotion)               
                .WithOne()                                
                .HasForeignKey<PriceOffer>(p => p.ProductId);

            entity.HasMany(p => p.Reviews)
                .WithOne()
                .HasForeignKey(p => p.ProductId);

            entity.HasMany(p => p.SuppliersLink)
                  .WithMany(p => p.ProductsLink)
                  .UsingEntity<ProductSupplier>(
                    productSupplier => productSupplier.HasOne(p => p.Supplier)
                                                      .WithMany().HasForeignKey("SupplierId"),
                    productSupplier => productSupplier.HasOne(p => p.Product)
                                                      .WithMany().HasForeignKey("ProductId"));
        }
    }
}
